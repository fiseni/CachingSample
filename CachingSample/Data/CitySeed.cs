using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Data
{
    public static class CitySeed
    {
        public static List<City> GetTestData()
        {
            var output = new List<City>();

            for (int i = 1; i <= 100; i++)
            {
                output.Add(new City
                {
                    Name = $"City{i}",
                    Code = $"Code{i}",
                });
            }

            return output;
        }
    }
}
