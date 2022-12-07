using ManagedIdentityPoC.Data.Domain;
using ManagedIdentityPoC.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException("dataContext");
        }

        public async Task<IEnumerable<CountryEntity>> GetAllCountriesAsync()
        {
            return await _dataContext.Countries.ToListAsync();
        }

        public async Task<CountryEntity> GetCountryByIdAsync(int id)
        {
            return await _dataContext.Countries.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCountryAsync(CountryEntity data)
        {
            _dataContext.Add(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateCountryAsync(CountryEntity data)
        {
            _dataContext.Update(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteCountryAsync(int id)
        {
            var item = await GetCountryByIdAsync(id);

            _dataContext.Countries.Remove(item);
            await _dataContext.SaveChangesAsync();
        }
    }
}
