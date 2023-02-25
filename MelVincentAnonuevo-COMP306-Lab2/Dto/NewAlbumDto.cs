

using System.ComponentModel.DataAnnotations;

namespace MelVincentAnonuevo_COMP306_Lab2.Dto
{
    public class NewAlbumDto
    {
        [Required]
        public string name { get; set; }
    }
}