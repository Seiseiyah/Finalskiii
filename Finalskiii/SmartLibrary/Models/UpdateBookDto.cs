namespace Finalskiii.SmartLibrary.Models
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string ISBN { get; set; } = "";
        public string Category { get; set; } = "";
        public string Status { get; set; } = "Available";
    }
}
