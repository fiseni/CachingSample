using CachingSample.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.DataAccess
{
    public class AppDbContextSeed
    {
        private readonly AppDbContext dbContext;

        public AppDbContextSeed(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SeedAsync(int retry = 0)
        {
            try
            {
                dbContext.Database.Migrate();

                if (!await dbContext.Customers.AnyAsync())
                {
                    dbContext.Customers.AddRange(CustomerSeed.GetTestData());
                }

                if (!await dbContext.Countries.AnyAsync())
                {
                    dbContext.Countries.AddRange(CountrySeed.GetTestData());
                }

                if (!await dbContext.Cities.AnyAsync())
                {
                    dbContext.Cities.AddRange(CitySeed.GetTestData());
                }

                await dbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                if (retry > 0)
                {
                    await SeedAsync(retry - 1);
                }
            }
        }
    }
}
