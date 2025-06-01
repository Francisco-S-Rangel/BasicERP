using System.ComponentModel.DataAnnotations;

namespace BasicERP.Domain
{
    public class Department : EntityBase
    {
        [Required]
        public string Acronym { get; set; }

        public string? Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
