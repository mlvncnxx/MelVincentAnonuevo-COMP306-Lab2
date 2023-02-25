using System;
using System.ComponentModel.DataAnnotations;

namespace MelVincentAnonuevo_COMP306_Lab2.Dto
{
    public class NewImageDto
    {
        [Required]
        public Guid album_id { get; set; }
        
        [Required]
        public string caption { get; set; }
    }
}