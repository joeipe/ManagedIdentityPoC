using Azure;
using Azure.Data.Tables;
using System;

namespace ManagedIdentityPoC.Integration.TableStorage.Domain
{
    public class PersonEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}