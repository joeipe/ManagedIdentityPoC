using Azure.Data.Tables;
using ManagedIdentityPoC.Integration.TableStorage.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.Integration.TableStorage.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TableClient _client;

        public PersonRepository(TableServiceClient tableServiceClient)
        {
            _client = tableServiceClient.GetTableClient("People");
            _client.CreateIfNotExists();
        }

        public async Task<List<PersonEntity>> GetAllPersonAsync()
        {
            var result = new List<PersonEntity>();

            var personEntities = _client.QueryAsync<PersonEntity>();
            result = await personEntities.ToListAsync();

            return result;
        }

        public async Task<PersonEntity> GetPersonByIdAsync(string partitionKey, string rowKey)
        {
            var result = await _client.GetEntityAsync<PersonEntity>(partitionKey, rowKey);
            return result;
        }

        public async Task AddPersonAsync(PersonEntity value)
        {
            await _client.AddEntityAsync(value);
        }

        public async Task UpdatePersonAsync(PersonEntity value)
        {
            await _client.UpsertEntityAsync(value);
        }

        public async Task DeletePersonAsync(string partitionKey, string rowKey)
        {
            await _client.DeleteEntityAsync(partitionKey, rowKey);
        }
    }
}