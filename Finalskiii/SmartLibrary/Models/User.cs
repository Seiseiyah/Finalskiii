using Finalskiii.Finalskiii.Enums;
using Finalskiii.Controllers;

namespace Finalskiii.Finalskiii.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
 