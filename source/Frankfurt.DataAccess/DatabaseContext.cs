using Frankfurt.Model;
using Microsoft.EntityFrameworkCore;

namespace Frankfurt.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().Property(a => a.Title).IsRequired();
                modelBuilder.Entity<Account>().HasOne(a => a.User).WithMany(u => u.Accounts).OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
                

            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.TargetAccount).WithMany().OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.SourceAccount).WithMany().OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
        }
    }
}
