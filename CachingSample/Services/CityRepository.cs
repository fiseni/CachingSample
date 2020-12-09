using CachingSample.Data;
using CachingSample.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Services
{
    public class CityRepository
    {
        private readonly AppDbContext dbContext;

        public CityRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<City>> GetCities()
        {
            return dbContext.Cities.ToListAsync();
        }
    }
}
