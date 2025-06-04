using BasicERP.Persistence.Context;
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

                var departmentDTOList = departments.Select(department => new DepartmentDTO
                {
                    Acronym = department.Acronym,
                    Description = department.Description,
                }).ToList();

                return Ok(new Result<List<DepartmentDTO>>("Departments found.", departmentDTOList));
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>(ex.Message));
            }
        }
    }
}
