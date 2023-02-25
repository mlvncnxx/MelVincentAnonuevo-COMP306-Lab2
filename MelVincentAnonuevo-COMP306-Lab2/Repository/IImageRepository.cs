using MelVincentAnonuevo_COMP306_Lab2.Models;

namespace MelVincentAnonuevo_COMP306_Lab2.Repository
{
    public interface IImageRepository
    {
        Task<Image> Add(Image image);
    
        Task<Image> FindById(Guid id);

        Task<Image> FindByCaption(string caption);

        Task Delete(Image image);
    }
}