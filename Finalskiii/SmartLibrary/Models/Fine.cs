namespace Finalskiii.Finalskiii.Models
{
    public class Fine
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public bool Paid { get; set; } = false;
    }
}
