using ELDNET_Lloyd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ELDNET_Lloyd.Data
{
    public class ApplicationDbContext : IdentityDbContext<Student, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<GatePass> GatePasses { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
