using AutoMapper;
using ManagedIdentityPoC.Contract;
using ManagedIdentityPoC.Integration.TableStorage.Domain;
using ManagedIdentityPoC.Integration.TableStorage.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.Application.Services
{
    public class AppService : IAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public AppService(
            IMapper mapper,
            IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
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
    }
}