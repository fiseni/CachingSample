using CachingSample.Data;
using CachingSample.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CachingSample.Services
{
    public interface ICachedDataService : ICacheInfo
    {
        Task Reload(AppDbContext dbContext);
    }
}