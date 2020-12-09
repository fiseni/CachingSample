using CachingSample.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CachingSample.Services
{
    public interface ICityRepository
    {
        Task<List<City>> GetCities();
    }
}