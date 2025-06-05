using BasicERP.Domain;
using BasicERP.Services.DTO;

namespace BasicERP.Persistence.Mapping
{
    public static class DepartmentMapping
    {
        public static DepartmentDTO MapDepartment(this Department department)
        {
            return new DepartmentDTO()
            {
                Id = department.Id,
                Name = department.Name,
                IsActive = department.IsActive,
                CreationDate = department.CreationDate,
                ModificationDate = department.ModificationDate,
                ImageUrl = department.ImageUrl,
                Acronym = department.Acronym,
                Description = department.Description
            };
        }

        public static Department MapDepartmentDTO(this DepartmentDTO departmentDTO)
        {
            return new Department()
            {
                Id = departmentDTO.Id,
                Name = departmentDTO.Name,
                IsActive = departmentDTO.IsActive,
                CreationDate = departmentDTO.CreationDate,
                ModificationDate = departmentDTO.ModificationDate,
                ImageUrl = departmentDTO.ImageUrl,
                Acronym = departmentDTO.Acronym,
                Description = departmentDTO.Description
            };
        }
    }
}
