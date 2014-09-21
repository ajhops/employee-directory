using System.Data.Entity;
using Employee.Core.Entities;

namespace Employee.Core
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("BlogContext")
        {
            
        }

        public DbSet<Entities.Employee> Employees { get; set; }
    }
}
