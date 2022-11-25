using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Office.Models;

namespace Office.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Emp>? Employees { get; set; }
        public DbSet<DepartmentRole>? DepartmentRoles { get; set; }
        public DbSet<WorkReport>? WorkReports { get; set; }
        public DbSet<UserRole>? UserRole { get; set; }
    }
}
