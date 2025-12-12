using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finalskiii.Finalskiii.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public required string ISBN { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Publisher { get; set; }
        public required DateOnly YearPublish { get; set; }
        public required string Category { get; set; }
        public required bool isBorrowed { get; set; } = false;
        public required string Condition { get; set; }
        public required string CreatedBy { get; set; }
        public required DateTime CreatedAt { get; set; }    
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}