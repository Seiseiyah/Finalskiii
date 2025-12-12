using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finalskiii.Finalskiii.Models
{
    public class Loan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        public required int ClientId { get; set; }
        public required string TransactionType { get; set; }     // Borrow, Damage, Lost
        public DateOnly? ReservedDate { get; set; }
        public required DateOnly BorrowDate { get; set; }
        public required DateOnly DueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public List<int>? book_id { get; set; } = [];
        public required string TransactionStatus { get; set; }
        public int? FineId { get; set; }
        public required string CreatedBy { get; set; }
        public required DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
