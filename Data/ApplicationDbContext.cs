using Microsoft.EntityFrameworkCore;
using RatMaintenance.Models;

namespace RatMaintenance.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<RAT> RATs { get; set; }
    }
}
