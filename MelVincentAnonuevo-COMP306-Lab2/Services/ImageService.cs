using System;
using MelVincentAnonuevo_COMP306_Lab2.Models;
using MelVincentAnonuevo_COMP306_Lab2.Repository;

namespace MelVincentAnonuevo_COMP306_Lab2.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Task<Image> Create(Image image)
        {
            image.Id = Guid.NewGuid();
            return _imageRepository.Add(image);
        }

        public Task Delete(Image image)
        {
            //add delete logic
            return _imageRepository.Delete(image);
                     
        }

        public Task<Image> FindById(Guid id)
        {
            return _imageRepository.FindById(id);
        }

        public Task<Image> FindByCaption(string caption)
        {
            return _imageRepository.FindByCaption(caption);
        }
    }
}