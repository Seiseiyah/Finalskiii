using Finalskiii.Finalskiii.Enums;
namespace Finalskiii.Finalskiii.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = "";
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public BookStatus Status { get; set; } = BookStatus.Available;
        public string Category { get; internal set; }

        public static implicit operator Book(Book v)
        {
            return new Book
            {
                Id = v.Id,
                ISBN = v.ISBN,
                Title = v.Title,
                Author = v.Author,
                Status = v.Status,
                Category = v.Category
            };
        }
    }
}
