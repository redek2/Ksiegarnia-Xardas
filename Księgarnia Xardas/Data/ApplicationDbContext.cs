using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using księgarnia_Xardas.Models;

namespace księgarnia_Xardas.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<UserActivityReport> UserActivityReports { get; set; }
        public DbSet<UserRegistrationReport> UserRegistrationReports { get; set; }
        public DbSet<UserBorrowingReport> UserBorrowingReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserActivityReport>().HasNoKey();
            modelBuilder.Entity<UserRegistrationReport>().HasNoKey();
            modelBuilder.Entity<UserBorrowingReport>().HasNoKey();
        }
    }
}
