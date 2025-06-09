using BasicERP.Domain;
using BasicERP.Persistence.Context;
using BasicERP.Persistence.Mapping;
using BasicERP.Services.DTO;
using BasicERP.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BasicERP.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly BasicERPContext _context;

        public EmployeeController(BasicERPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _context.Employees.ToList();
                var employeeDTOList = employees.Select(employee => employee.MapEmployee()).ToList();

                return Ok(new Result<List<EmployeeDTO>>("Employees found.", employeeDTOList));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An internal error occorred: {ex.Message}"));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            try
            {
                var employeeDTO = employee.MapEmployee();

                return Ok(new Result<EmployeeDTO>("Employee found.", employeeDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An internal error occorred: {ex.Message}"));
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
                return BadRequest("ID in URL and Employee body do not match");

            try
            {
                var updateEmployee = _context.Employees.Find(id);

                if (updateEmployee == null)
                    return NotFound($"Employee with ID {id} not found.");

                updateEmployee.Name = employeeDTO.Name;
                updateEmployee.DocumentId = employeeDTO.DocumentId;
                updateEmployee.BirthDate = employeeDTO.BirthDate.Date;
                updateEmployee.Role = employeeDTO.Role;
                updateEmployee.Gender = employeeDTO.Gender;
                updateEmployee.DepartmentId = employeeDTO.DepartmentId;
                updateEmployee.ImageUrl = employeeDTO.ImageUrl;
                updateEmployee.IsActive = employeeDTO.IsActive;
                updateEmployee.ModificationDate = DateTime.UtcNow;

                _context.Employees.Update(updateEmployee);
                _context.SaveChanges();

                return Ok(new Result<string>("Employee updated."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An error occorred while updating the employee: {ex.Message}."));
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                employeeDTO.GenerateNewEntity();
                var newEmployee = employeeDTO.MapEmployeeDTO();

                _context.Employees.Add(newEmployee);
                _context.SaveChanges();

                return Ok(new Result<string>("Employee create successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An error occorred while creating the employee: {ex.Message}"));
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            try
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();

                return Ok(new Result<object>("Employee deleted."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An internal error occorred: {ex.Message}"));
            }
        }

        [Route("{name}/getEmployeesByName")]
        [HttpGet]
        public IActionResult GetEmployeesByName(string name)
        {
            var employees = _context.Employees.Where(employee =>
                employee.Name.ToLower().Contains(name.ToLower().Trim())).ToList();

            if (employees.Count == 0)
                return NotFound($"No employee was found with the name: {name}.");

            try
            {
                var employeeDTOList = employees.Select(employee =>
                    employee.MapEmployee()).ToList();

                return Ok(new Result<List<EmployeeDTO>>("Employees found.", employeeDTOList));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An internal error occorred: {ex.Message}"));
            }
        }

        [Route("{departmentId}/getEmployeesByDepartmentId")]
        [HttpGet]
        public IActionResult GetEmployeesByDepartmentId(Guid departmentId)
        {
            var department = _context.Departments.Find(departmentId);

            if (department == null)
                return NotFound($"Department with ID {departmentId} not found.");

            try
            {
                var employees = _context.Employees.Where(employee =>
                employee.DepartmentId == departmentId).ToList();

                if (employees.Count == 0)
                    return NotFound("No employee was found within this department.");

                var employeeDTOList = employees.Select(employee => employee.MapEmployee()).ToList();

                return Ok(new Result<List<EmployeeDTO>>("Employees found.", employeeDTOList));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result<object>($"An internal error occorred: {ex.Message}"));
            }
        }
    }
}
