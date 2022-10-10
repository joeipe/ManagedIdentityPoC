namespace ManagedIdentityPoC.Contract
{
    public class PersonDto
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}