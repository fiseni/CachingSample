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
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly AppDbContext dbContext;
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ILogger<CustomersController> logger,
                                   AppDbContext dbContext,
                                   ICustomerRepository customerRepository)
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerRepository.Customers;
        }

        [HttpPost]
        public async Task Post(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                Email = customerDto.Email,
            };

            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
        }
    }
}
