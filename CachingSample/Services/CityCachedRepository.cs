using CachingSample.Data;
using CachingSample.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Services
{
    public class CityCachedRepository : ICityRepository
    {
        private readonly IMemoryCache cache;
        private readonly CityRepository cityRepository;

        private readonly string cacheKey = nameof(City);
        private readonly TimeSpan cacheDuration = TimeSpan.FromSeconds(5);

        public CityCachedRepository(IMemoryCache cache,
                                    CityRepository cityRepository)
        {
            this.cache = cache;
            this.cityRepository = cityRepository;
        }

        public Task<List<City>> GetCities()
        {
            return cache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SlidingExpiration = cacheDuration;
                return cityRepository.GetCities();
            });
        }
    }
}
