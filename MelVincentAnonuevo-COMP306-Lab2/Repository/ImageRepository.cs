using MelVincentAnonuevo_COMP306_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace MelVincentAnonuevo_COMP306_Lab2.Repository
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<Image> Add(Image image)
        {
            _dbContext.Images.Add(image);
            await _dbContext.SaveChangesAsync();
            return image;
        }

        public async Task Delete(Image image)
        {
            _dbContext.Images.Remove(image);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Image> FindById(Guid id)
        {
            return await _dbContext.Images
                                   .Where(i => i.Id == id)
                                   .FirstOrDefaultAsync();
        }

        public async Task<Image> FindByCaption(string caption)
        {
            return await _dbContext.Images
                                   .Where(i => i.Caption == caption)
                                   .FirstOrDefaultAsync();
        }
    }
}