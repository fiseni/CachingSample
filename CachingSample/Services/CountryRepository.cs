using CachingSample.Data;
using CachingSample.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Services
{
    public class CountryRepository : ICountryRepository, ICachedDataService
    {
        private static readonly object _instanceLock = new object();

        public string CacheKey { get; } = nameof(Country);

        public IEnumerable<Country> Countries { get; private set; }

        public async Task Reload(AppDbContext dbContext)
        {
            var countries = await dbContext.Countries.ToListAsync();
            lock (_instanceLock)
            {
                Countries = countries;
            }
        }
    }
}
