using EmpEntryFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmpEntryFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Visitors> Visitors { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> Designation { get; set; }
      


    }
}