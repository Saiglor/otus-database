using Microsoft.EntityFrameworkCore;
using Otus.Models.Models;
using Otus.PostgreSql.Configurations;

namespace Otus.PostgreSql
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<ClientProfileModel> ClientProfiles { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ItemTypeModel> ItemTypes { get; set; }

        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientProfileConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString).UseLazyLoadingProxies();
        }
    }
}