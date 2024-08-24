using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeFirstGabrielCampos.Entities
{
    public class EFCoreDbContext : DbContext
    {

        // Parameterless constructor for design-time operations
        public EFCoreDbContext()
        {
        }
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options)
                    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Bank)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.BankId);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Bank> Banks { get; set; }
    
    }
}
