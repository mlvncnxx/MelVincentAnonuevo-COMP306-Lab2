using MelVincentAnonuevo_COMP306_Lab2.Models;
using System;

namespace MelVincentAnonuevo_COMP306_Lab2.Services
{
    public interface IImageService
    {
        Task<Image> FindById(Guid id);

        Task<Image> Create(Image image);

        Task<Image> FindByCaption(string caption);

        Task Delete(Image image);      
    }
}