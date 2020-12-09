using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.Data
{
    public interface ICacheInfo
    {
        string CacheKey { get; }
    }
}
