using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{

    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }

      
    }
}
