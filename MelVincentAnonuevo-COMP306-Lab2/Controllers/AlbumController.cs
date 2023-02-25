using Amazon.S3;
using MelVincentAnonuevo_COMP306_Lab2.Dto;
using MelVincentAnonuevo_COMP306_Lab2.Services;
using Microsoft.AspNetCore.Mvc;

namespace MelVincentAnonuevo_COMP306_Lab2.Controllers
{
    [Route("album")]
    public class AlbumController : BaseController<AlbumController>
    {
        private readonly IAlbumService _albumService;
        private readonly IAmazonS3 _s3Client;

        public AlbumController(ILogger<AlbumController> logger, IAlbumService albumService, IAmazonS3 s3Client) : base(logger)
        {
            _albumService = albumService;
            _s3Client = s3Client;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NewAlbumDto newAlbumDto)
        {
            try
            {
                return Ok(await _albumService.Create(newAlbumDto));
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
           var album = await _albumService.FindById(id);

           if (album == null)
           {
                return NotFound();
           }

           var imageList = new ImageListDto();
           imageList.images = album.Images;

           return Ok(imageList);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _albumService.FindAll());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var album = await _albumService.FindById(id);

            if(album == null)
            {
                return NotFound("Album not found");
            }
            try
            {
                await _albumService.Delete(album);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return NoContent();
        }
    }
}