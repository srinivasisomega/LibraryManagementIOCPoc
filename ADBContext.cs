using Microsoft.EntityFrameworkCore;
using LibraryManagementIOCPoc.models;

using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryManagementIOCPoc
{
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Lending> Lending { get; set; }

        public DbSet<models.Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=COGNINE-L78;Initial Catalog=bolobapppa;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Lending>().ToTable("Lending");
            // If using Transactions table
            modelBuilder.Entity<models.Transaction>().ToTable("Transactions");
        }
        

    }



}
