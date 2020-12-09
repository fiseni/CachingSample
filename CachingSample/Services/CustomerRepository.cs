using CachingSample.Data;
using CachingSample.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Services
{
    public class CustomerRepository : ICustomerRepository, ICachedDataService
    {
        private static readonly object _instanceLock = new object();

        public string CacheKey { get; } = nameof(Customer);

        public IEnumerable<Customer> Customers { get; private set; }

        public async Task Reload(AppDbContext dbContext)
        {
            var customers = await dbContext.Customers.ToListAsync();
            lock (_instanceLock)
            {
                Customers = customers;
            }
        }
    }
}
