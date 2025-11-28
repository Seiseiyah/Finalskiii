using Finalskiii.Finalskiii.Enums;
using Microsoft.IdentityModel.Tokens;

namespace Finalskiii.SmartLibrary.Models
{
    public class AddBookDto
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string ISBN { get; set; } = "";
        public string Category { get; set; } = "";
        public BookStatus Status { get; set; } = "";
    }
}
    