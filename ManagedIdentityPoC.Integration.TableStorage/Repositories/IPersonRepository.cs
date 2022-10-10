using ManagedIdentityPoC.Integration.TableStorage.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.Integration.TableStorage.Repositories
{
    public interface IPersonRepository
    {
        Task<List<PersonEntity>> GetAllPersonAsync();

        Task<PersonEntity> GetPersonByIdAsync(string partitionKey, string rowKey);

        Task AddPersonAsync(PersonEntity value);

        Task UpdatePersonAsync(PersonEntity value);

        Task DeletePersonAsync(string partitionKey, string rowKey);
    }
}