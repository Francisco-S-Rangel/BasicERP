using System.ComponentModel.DataAnnotations;

namespace BasicERP.Services.DTO
{
    public class DepartmentDTO : BaseDTO
    {
        [Required]
        public string Acronym { get; set; }

        public string? Description { get; set; }

        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
    }
}
