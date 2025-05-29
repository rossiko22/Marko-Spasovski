using LibraryManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Books)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .IsRequired();
        }
    }
}
