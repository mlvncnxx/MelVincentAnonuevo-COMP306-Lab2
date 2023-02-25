using MelVincentAnonuevo_COMP306_Lab2.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace MelVincentAnonuevo_COMP306_Lab2.Repository
{
    public class AlbumRepository : BaseRepository, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Album> Add(Album album)
        {
            _dbContext.Albums.Add(album);
            await _dbContext.SaveChangesAsync();
            return album;
        }

        public async Task<Album> FindById(Guid id)
        {
            return await _dbContext.Albums
                                   .Where(a => a.Id == id)
                                   .Include(a => a.Images)
                                   .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Album>> FindAll()
        {
            return await _dbContext.Albums.ToListAsync();
        }
        public async Task Delete(Album album)
        {
            _dbContext.Albums.Remove(album);
            await _dbContext.SaveChangesAsync();
        }
    }
}