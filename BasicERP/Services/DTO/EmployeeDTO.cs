using BasicERP.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace BasicERP.Services.DTO
{
    public class EmployeeDTO : BaseDTO
    {
        [Required]
        public string DocumentId { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }
    }
}
