using CachingSample.Data;
using CachingSample.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CachingSample.DataAccess
{
    public class AppDbContext : DbContext
    {
        private readonly IEnumerable<ICachedDataService> cachedDataServices;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options,
                            IEnumerable<ICachedDataService> cachedDataServices)
            : base(options)
        {
            this.cachedDataServices = cachedDataServices;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var keys = ChangeTracker.Entries<ICacheInfo>()
                                                 .Where(x => x.IsAddedOrModifiedOrDeleted())
                                                 .Select(x => x.Entity.CacheKey)
                                                 .Distinct()
                                                 .ToList();

            var response = await base.SaveChangesAsync(cancellationToken);

            foreach (var key in keys)
            {
                await cachedDataServices.FirstOrDefault(x => x.CacheKey.Equals(key))?.Reload(this);
            }

            return response;
        }

    }
}
