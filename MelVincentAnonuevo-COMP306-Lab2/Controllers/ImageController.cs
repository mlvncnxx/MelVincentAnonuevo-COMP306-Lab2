using Amazon.S3;
using Amazon.S3.Transfer;
using MelVincentAnonuevo_COMP306_Lab2.Models;
using MelVincentAnonuevo_COMP306_Lab2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MelVincentAnonuevo_COMP306_Lab2.Controllers
{
    [Route("albums/{album_id}/images")]
    public class ImageController : BaseController<ImageController>
    {
        private readonly IImageService _imageService;
        private readonly IAlbumService _albumService;
        private IFileUploadService _fileUploadService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAmazonS3 _s3Client;

        public ImageController(IImageService imageService,
            IAlbumService albumService,
            IFileUploadService fileUploadService,
            IWebHostEnvironment webHostEnvironment,
            IAmazonS3 s3Client,
            ILogger<ImageController> logger) : base(logger)
        {
            _imageService = imageService;
            _albumService = albumService;
            _fileUploadService = fileUploadService;
            _webHostEnvironment = webHostEnvironment;
            _s3Client = s3Client;
        }

        [HttpGet("{image_id}")]
        public async Task<IActionResult> FindByCaption(Guid album_id, string caption)
        {
            var image = await _imageService.FindByCaption(caption);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string caption,
                                                Guid id,
                                                [FromForm] IFormFile image,
                                                string bucketName)
        {
            var album = await _albumService.FindById(id);
            if (album == null)
            {
                return NotFound("Album not found");
            }

            var newImage = new Image();
            newImage.Caption = caption;
            
            if(image == null || image.Length == 0)
            {
                return BadRequest("File is empty");
            }

            //webrootpath
            string webRoot = _webHostEnvironment.WebRootPath;

            //get extension of uploaded file
            string extension = Path.GetExtension(image.FileName);

            //generate a file name, using GUID to avoid duplicaes
            string fileName = Path.Combine(webRoot + Guid.NewGuid().ToString() + extension);

            try
            {
                //upload file to S3
                var fileTransferUtility = new TransferUtility(_s3Client);
                await fileTransferUtility.UploadAsync(image.OpenReadStream(), bucketName, fileName);

                //save file name to database
                string uploadFileUrl = await _fileUploadService.UploadFile(image, bucketName);
                newImage.Url = uploadFileUrl;
                newImage.Album= album;
                newImage = await _imageService.Create(newImage);
            }
            catch (DbUpdateException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(newImage);
        }

        [HttpDelete("{image_id}")]
        public async Task<IActionResult> DeleteById(string bucketName, Guid album_id, Guid id)
        {
            var image = await _imageService.FindById(id);
            if (image == null)
            {
                return NotFound();
            }
            try
            {
                //delete file from S3
            
                await _s3Client.DeleteObjectAsync(bucketName, image.Url);

                //delete file from database
                await _imageService.Delete(image);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return NoContent();
        }
    }
}