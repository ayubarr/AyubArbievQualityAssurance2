using AyubArbievQualityAssurance2.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace QualityAssurance2.Data.DataBase.SqlServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string? connectionString = config
                .GetConnectionString("ConnectionString");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
