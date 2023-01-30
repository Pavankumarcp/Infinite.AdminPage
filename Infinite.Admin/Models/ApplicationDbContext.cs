using Microsoft.EntityFrameworkCore;

namespace Infinite.AdminPage.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<RegUser> Regdusers { get; set; }
        public DbSet<AdminHome> admins { get; set; }
    }
}
