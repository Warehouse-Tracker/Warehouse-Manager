using System;
using System.Linq;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WarehouseManager.Domain;

namespace WarehouseManager.DataAccess
{
    public class WarehouseManagerContext : ApiAuthorizationDbContext<User>
    {
        public WarehouseManagerContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<SupplyEntry> Entries { get; set; }

        public DbSet<EmployeeUser> Employees { get; set; }

        public DbSet<OwnerUser> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // for testing purposes use in memory database
                var connectionStringBuilder = new SqliteConnectionStringBuilder() { DataSource = ":memory:" };
                var connection = new SqliteConnection(connectionStringBuilder.ToString());
                optionsBuilder.UseSqlite(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO: Relations config
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.Name).Property<DateTime>("Created");
                builder.Entity(entityType.Name).Property<DateTime>("LastModified");
            }

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            DateTime timestamp = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified)
                             && !e.Metadata.IsOwned()))
            {
                entry.Property("LastModified").CurrentValue = timestamp;
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = timestamp;
                }
            }
            return base.SaveChanges();
        }
    }
}
