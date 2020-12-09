using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Data
{
    public static class CountrySeed
    {
        public static List<Country> GetTestData()
        {
            var output = new List<Country>();

            for (int i = 1; i <= 100; i++)
            {
                output.Add(new Country
                {
                    Name = $"Country{i}",
                    Code = $"Code{i}",
                });
            }

            return output;
        }
    }
}
