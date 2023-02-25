namespace MelVincentAnonuevo_COMP306_Lab2.Services
{
    public interface IFileUploadService
    {
        public Task<string> UploadFile(IFormFile file, string fileName);
    }
}