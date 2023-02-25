namespace MelVincentAnonuevo_COMP306_Lab2.Repository
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}