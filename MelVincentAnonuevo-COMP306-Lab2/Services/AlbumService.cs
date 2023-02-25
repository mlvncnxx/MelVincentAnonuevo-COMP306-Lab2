using MelVincentAnonuevo_COMP306_Lab2.Dto;
using MelVincentAnonuevo_COMP306_Lab2.Models;
using MelVincentAnonuevo_COMP306_Lab2.Repository;
using MelVincentAnonuevo_COMP306_Lab2.Services;

namespace MelVincentAnonuevo_comp306_lab2.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IImageService _imageService;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public Task<Album> Create(NewAlbumDto albumDto)
        {
            var newAlbum = new Album();
            newAlbum.Id = Guid.NewGuid();
            newAlbum.Name = albumDto.name;
            return _albumRepository.Add(newAlbum);
        }

        public Task Delete(Album album)
        {
            //add delete album logic
            _albumRepository.Delete(album);
            return _albumRepository.Delete(album);
        }

        public Task<IEnumerable<Album>> FindAll()
        {
            return _albumRepository.FindAll();
        }

        public Task<Album> FindById(Guid id)
        {
            return _albumRepository.FindById(id);
        }

    }
}