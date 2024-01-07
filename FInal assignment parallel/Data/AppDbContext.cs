using FInal_assignment_parallel.Model;
using Microsoft.EntityFrameworkCore;
namespace FInal_assignment_parallel.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Addresses)
                .HasForeignKey(a => a.StudentId);
        }

    }
}
