using BasicERP.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicERP.Persistence.Context
{
    public class BasicERPContext : DbContext
    {
        public BasicERPContext(DbContextOptions<BasicERPContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
