using BasicERP.Domain;
using BasicERP.Services.DTO;

namespace BasicERP.Persistence.Mapping
{
    public static class EmployeeMapping
    {
        public static EmployeeDTO MapEmployee(this Employee employee)
        {
            return new EmployeeDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                IsActive = employee.IsActive,
                CreationDate = employee.CreationDate,
                ModificationDate = employee.ModificationDate,
                ImageUrl = employee.ImageUrl,
                DocumentId = employee.DocumentId,
                BirthDate = employee.BirthDate,
                Role = employee.Role,
                Gender = employee.Gender,
                DepartmentId = employee.DepartmentId,
            };
        }

        public static Employee MapEmployeeDTO(this EmployeeDTO employeeDTO)
        {
            return new Employee()
            {
                Id = employeeDTO.Id,
                Name = employeeDTO.Name,
                IsActive = employeeDTO.IsActive,
                CreationDate = employeeDTO.CreationDate,
                ModificationDate = employeeDTO.ModificationDate,
                ImageUrl = employeeDTO.ImageUrl,
                DocumentId = employeeDTO.DocumentId,
                BirthDate = employeeDTO.BirthDate,
                Role = employeeDTO.Role,
                Gender = employeeDTO.Gender,
                DepartmentId = employeeDTO.DepartmentId,
            };
        }
    }
}
