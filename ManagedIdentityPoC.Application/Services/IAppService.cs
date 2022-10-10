using ManagedIdentityPoC.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.Application.Services
{
    public interface IAppService
    {
        Task<IList<PersonDto>> GetAllPersonAsync();

        Task<PersonDto> GetPersonByIdAsync(string partitionKey, string rowKey);

        Task AddPersonAsync(PersonDto value);

        Task UpdatePersonAsync(PersonDto value);

        Task DeletePersonAsync(string partitionKey, string rowKey);
    }
}