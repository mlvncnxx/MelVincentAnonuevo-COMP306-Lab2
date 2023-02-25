using System;
using MelVincentAnonuevo_COMP306_Lab2.Models;
using MelVincentAnonuevo_COMP306_Lab2.Dto;

namespace MelVincentAnonuevo_COMP306_Lab2.Services
{
    public interface IAlbumService
    {
        Task<Album> FindById(Guid id);

        Task<Album> Create(NewAlbumDto album);

        Task<IEnumerable<Album>> FindAll();

        Task Delete(Album album);
    }
}