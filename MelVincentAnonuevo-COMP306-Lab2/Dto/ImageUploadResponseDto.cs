namespace MelVincentAnonuevo_COMP306_Lab2.Dto
{
    public class ImageUploadResponseDto
    {
        public string url { get; set; }

        public string caption { get; set; }

        public Guid id { get; set;}

        public Guid album_id { get; set; }
    }
}