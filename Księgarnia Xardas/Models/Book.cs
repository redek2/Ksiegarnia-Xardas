using System.ComponentModel.DataAnnotations;

namespace księgarnia_Xardas.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(50, ErrorMessage = "Author cannot exceed 50 characters.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Copies Available must be non-negative.")]
        public int CopiesAvailable { get; set; }
    }
}