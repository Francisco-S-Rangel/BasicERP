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
    }
}
