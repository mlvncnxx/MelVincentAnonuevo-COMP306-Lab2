using MelVincentAnonuevo_COMP306_Lab2.Models;

namespace MelVincentAnonuevo_COMP306_Lab2.Repository
{
    public interface IAlbumRepository
    {
        Task<Album> Add(Album image);
    
        Task<Album> FindById(Guid id);

        Task<IEnumerable<Album>> FindAll();

        Task Delete(Album album);
    }
}