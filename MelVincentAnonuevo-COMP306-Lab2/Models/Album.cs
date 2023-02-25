using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MelVincentAnonuevo_COMP306_Lab2.Models
{
    [Table("albums")]
    public class Album
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [JsonIgnore]
        public IEnumerable<Image> Images { get; set; }

    }
}
