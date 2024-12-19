using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.DBEntities;

namespace WebApplication3.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
