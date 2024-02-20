using Microsoft.EntityFrameworkCore;

namespace day2_mvc.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() { }
         public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Works_For> WorkFor { get; set; }
        public DbSet<Dependent> Dependents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.;Database=day5;Trusted_Connection=True;TrustServerCertificate=True");

        }

    }
    }

