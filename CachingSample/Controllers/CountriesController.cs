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
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly AppDbContext dbContext;
        private readonly ICountryRepository countryRepository;

        public CountriesController(ILogger<CountriesController> logger,
                                   AppDbContext dbContext,
                                   ICountryRepository countryRepository)
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return countryRepository.Countries;
        }

        [HttpPost]
        public async Task Post(CountryDto countryDtp)
        {
            var country = new Country
            {
                Name = countryDtp.Name,
                Code = countryDtp.Code
            };

            await dbContext.Countries.AddAsync(country);
            await dbContext.SaveChangesAsync();
        }
    }
}
