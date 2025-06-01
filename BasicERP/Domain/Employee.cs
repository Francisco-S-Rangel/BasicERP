using BasicERP.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace BasicERP.Domain
{
    public class Employee : EntityBase
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

        [Required]
        public Department Department { get; set; }

    }
}
