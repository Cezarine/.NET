using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FilmesAPI.Models
{
    public class MovieVM
    {
        public int ID { get; set; }

        [Required (ErrorMessage = "The title is requerid")]
        [MaxLength (100)]
        public String Title { get; set; }

        [Required(ErrorMessage = "The gender is requerid")]
        [MaxLength (30, ErrorMessage = "Length cannot exceed 30 characters")]
        public String Gender { get; set; } //Genero

        [Required(ErrorMessage = "The duration is requerid")]
        [Range(70, 600, ErrorMessage = "The duration must be between 70 and 600 minutes")]
        public int Duration { get; set; }
    }
}
