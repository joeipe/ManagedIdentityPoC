using Azure.Identity;
using ManagedIdentityPoC.Data.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ManagedIdentityPoC.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CountryEntity> Countries { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ManagedIdentityPoCDb;Trusted_Connection=True;");
        }
        */

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            var connection = (SqlConnection)Database.GetDbConnection();
            var credential = new DefaultAzureCredential();
            var token = credential.GetToken(new Azure.Core.TokenRequestContext(new[] { "https://database.windows.net/.default" }));
            connection.AccessToken = token.Token;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}