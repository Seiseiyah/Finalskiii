using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finalskiii.Finalskiii.Enums;

namespace Finalskiii.Finalskiii.DTOs
{
    public class AddUserDTOs
    {
        public required string FullName { get; set; }
        public required string Username { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

    }
        public class UpdateUserDTO
        {
            public required string Username { get; set; } 
        }
        public class GetUserDTO
        {
            public required string Fullname { get; set; }
            public required int UserId { get; set; }

            public required string Username { get; set; }

            public required string Email { get; set; }
            public required string Role { get; set; }
        }
    public class LoginDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}

