using SmartsLibrary.Core.Models;


namespace Finalskiii.Finalskiii.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public List<Book> Books { get; set; } = new();
    }
}