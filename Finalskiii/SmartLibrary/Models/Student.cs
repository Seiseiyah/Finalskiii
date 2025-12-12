using Finalskiii.Finalskiii.Enums;
using Finalskiii.Finalskiii.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finalskiii.Finalskiii.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        public required int UserId { get; set; }

        [Required]
        public required int GradeLevel { get; set; }

        [Required]
        public required string Course { get; set; }
    }
}