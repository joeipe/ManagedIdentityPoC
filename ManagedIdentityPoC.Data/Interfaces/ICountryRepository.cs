using ManagedIdentityPoC.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.Data.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryEntity>> GetAllCountriesAsync();
        Task<CountryEntity> GetCountryByIdAsync(int id);
        Task AddCountryAsync(CountryEntity data);
        Task UpdateCountryAsync(CountryEntity data);
        Task DeleteCountryAsync(int id);
    }
}
