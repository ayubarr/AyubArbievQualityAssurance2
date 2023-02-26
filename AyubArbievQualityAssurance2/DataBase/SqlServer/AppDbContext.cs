using AyubArbievQualityAssurance2.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QualityAssurance2.Data.DataBase.SqlServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Client> Client { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(order => order.Client)
                .WithMany(client => client.Orders)
                .HasForeignKey(order => order.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasMany(client => client.Orders)
                .WithOne(order => order.Client)
                .HasForeignKey(order => order.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string? connectionString = config
                .GetConnectionString("ConnectionString2");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
