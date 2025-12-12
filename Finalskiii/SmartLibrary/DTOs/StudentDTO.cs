using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finalskiii.Finalskiii.DTOs
{
    public class AddStudentDTO
    {
        public required int UserId { get; set; }
        public required int GradeLevel { get; set; }
        public required string Course { get; set; }
    }

    public class GetStudentDTO
    {
        public required int StudentId { get; set; }
        public required int UserId { get; set; }
        public required int GradeLevel { get; set; }
        public required string Course { get; set; }
    }

    public class GetUserInformationStudent
    {
        public required int StudentId { get; set; }
        public required int UserId { get; set; }
        public required string FullName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required int GradeLevel { get; set; }
        public required string Course { get; set; }
    }
}
