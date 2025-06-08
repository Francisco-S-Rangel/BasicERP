using BasicERP.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BasicERP.Services.DTO
{
    public class EmployeeDTO : BaseDTO
    {
        [Required]
        public string DocumentId { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }
    }
}
