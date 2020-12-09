using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Data
{
    public class Country : ICacheInfo
    {
        public string CacheKey => nameof(Country);

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
