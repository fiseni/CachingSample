using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Data
{
    public static class CustomerSeed
    {
        public static List<Customer> GetTestData()
        {
            List<Customer> output = new List<Customer>();

            for (int i = 1; i <= 100; i++)
            {
                output.Add(new Customer
                {
                    Name = $"Customer{i}",
                    Address = $"Customer{i} address",
                    Email = $"Email{i}@local"
                });
            }

            return output;
        }
    }
}
