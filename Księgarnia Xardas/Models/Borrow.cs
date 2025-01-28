using System;
using System.ComponentModel.DataAnnotations;

namespace księgarnia_Xardas.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }
        public DateTime? DateDue { get; set; }
    }
}