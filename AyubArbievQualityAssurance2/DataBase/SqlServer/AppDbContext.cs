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

            modelBuilder.Entity<Client>()
              .HasMany(client => client.Orders)
              .WithOne(order => order.Client)
              .HasForeignKey(order => order.Id);

            modelBuilder.Entity<Client>(builder =>
            {
                builder.Property(c => c.Id).ValueGeneratedOnAdd();
                builder.HasData(new Client
                {
                    Id = 1,
                    FirstName = "Adm",
                    LastName = "Adminuch",
                    PhoneNum = "0555 555 555",
                    OrderAmount = 0,
                    DateAdd = DateTime.Now,  
                });
            });


            modelBuilder.Entity<Order>()
                .HasOne(order => order.Client)
                .WithMany(client => client.Orders)
                .HasForeignKey(order => order.ClientId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Order>(builder =>
            {
                builder.Property(o => o.Id).ValueGeneratedOnAdd();
            });

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
