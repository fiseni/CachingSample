using CachingSample.Data;
using CachingSample.DataAccess;
using CachingSample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly AppDbContext dbContext;
        private readonly ICityRepository cityRepository;

        public CityController(ILogger<CityController> logger,
                                   AppDbContext dbContext,
                                   ICityRepository cityRepository)
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public Task<List<City>> Get()
        {
            return cityRepository.GetCities();
        }

        [HttpPost]
        public async Task Post(CityDto cityDto)
        {
            var city = new City
            {
                Name = cityDto.Name,
                Code = cityDto.Code
            };

            await dbContext.Cities.AddAsync(city);
            await dbContext.SaveChangesAsync();
        }
    }
}
