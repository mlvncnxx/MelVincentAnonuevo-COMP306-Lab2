

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelVincentAnonuevo_COMP306_Lab2.Models
{
    [Table("images")]
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Caption { get; set; }

        [Required]
        public string? Url { get; set; }

        [Required]
        public Album? Album { get; set; }
    }
}