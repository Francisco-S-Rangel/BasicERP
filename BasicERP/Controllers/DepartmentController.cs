using BasicERP.Persistence.Context;
using BasicERP.Persistence.Mapping;
using BasicERP.Services.DTO;
using BasicERP.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly BasicERPContext _context;

        public DepartmentController(BasicERPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            try
            {
                var departments = _context.Departments.ToList();
                var departmentDTOList = departments.Select(department => department.MapDepartment()).ToList();

                return Ok(new Result<List<DepartmentDTO>>("Departments found.", departmentDTOList));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An internal error occorred: {ex.Message}"));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(Guid id)
        {
            try
            {
                var department = _context.Departments.Find(id);
                var departmentDTO = department.MapDepartment();

                return Ok(new Result<DepartmentDTO>("Deepartment found.", departmentDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An internal error occorred: {ex.Message}"));
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(Guid id, [FromBody] DepartmentDTO departmentDTO)
        {
            if (id != departmentDTO.Id )
                return BadRequest("ID in URL and Department body do not match.");

            try
            {
                var updateDepartment = _context.Departments.Find(id);

                if (updateDepartment == null)
                    return NotFound($"Department with ID {id} not found.");

                updateDepartment.Name = departmentDTO.Name;
                updateDepartment.Acronym = departmentDTO.Acronym;
                updateDepartment.Description = departmentDTO.Description;
                updateDepartment.ImageUrl = departmentDTO.ImageUrl;
                updateDepartment.IsActive = departmentDTO.IsActive;
                updateDepartment.ModificationDate = DateTime.Now;

                _context.Departments.Update(updateDepartment);
                _context.SaveChanges();

                return Ok(new Result<string>("Department updated."));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new Result<object>($"An error occorred while updating the department: {ex.Message}."));
            }
        }

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            try
            {
                departmentDTO.GenerateNewEntity();
                var newDepartment = departmentDTO.MapDepartmentDTO();

                _context.Departments.Add(newDepartment);
                _context.SaveChanges();

                return Ok(new Result<string>("Department created successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An error occorred while creadting the department: {ex.Message}."));
            }
        }
    }
}
