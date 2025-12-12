using Finalskiii.Finalskiii.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finalskiii.Finalskiii.Models
{
    public class Faculty 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacultytId { get; set; }
        public required int UserId { get; set; }
        public required string Department { get; set; }
        public required string Position { get; set; }
    }
}
