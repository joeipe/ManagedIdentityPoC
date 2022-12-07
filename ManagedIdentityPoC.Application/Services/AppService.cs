using AutoMapper;
using ManagedIdentityPoC.Contract;
using ManagedIdentityPoC.Data.Domain;
using ManagedIdentityPoC.Data.Interfaces;
using ManagedIdentityPoC.Integration.TableStorage.Domain;
using ManagedIdentityPoC.Integration.TableStorage.Repositories;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.Application.Services
{
    public class AppService : IAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly ICountryRepository _countryRepository;

        public AppService(
            IMapper mapper,
            IPersonRepository personRepository,
            ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _countryRepository = countryRepository;
        }

        public async Task<IList<PersonDto>> GetAllPersonAsync()
        {
            var data = await _personRepository.GetAllPersonAsync();
            var vm = _mapper.Map<IList<PersonDto>>(data);
            return vm;
        }

        public async Task<PersonDto> GetPersonByIdAsync(string partitionKey, string rowKey)
        {
            var data = await _personRepository.GetPersonByIdAsync(partitionKey, rowKey);
            var vm = _mapper.Map<PersonDto>(data);
            return vm;
        }

        public async Task AddPersonAsync(PersonDto value)
        {
            var data = _mapper.Map<PersonEntity>(value);
            await _personRepository.AddPersonAsync(data);
        }

        public async Task UpdatePersonAsync(PersonDto value)
        {
            var data = _mapper.Map<PersonEntity>(value);
            await _personRepository.UpdatePersonAsync(data);
        }

        public async Task DeletePersonAsync(string partitionKey, string rowKey)
        {
            await _personRepository.DeletePersonAsync(partitionKey, rowKey);
        }



        public async Task<IList<CountryDto>> GetAllCountriesAsync()
        {
            var data = await _countryRepository.GetAllCountriesAsync();
            var vm = _mapper.Map<IList<CountryDto>>(data);
            return vm;
        }

        public async Task<CountryDto> GetCountryByIdAsync(int id)
        {
            var data = await _countryRepository.GetCountryByIdAsync(id);
            var vm = _mapper.Map<CountryDto>(data);
            return vm;
        }

        public async Task AddCountryAsync(CountryDto value)
        {
            var data = _mapper.Map<CountryEntity>(value);
            await _countryRepository.AddCountryAsync(data);
        }

        public async Task UpdateCountryAsync(CountryDto value)
        {
            var data = _mapper.Map<CountryEntity>(value);
            await _countryRepository.UpdateCountryAsync(data);
        }

        public async Task DeleteCountryAsync(int id)
        {
            await _countryRepository.DeleteCountryAsync(id);
        }
    }
}