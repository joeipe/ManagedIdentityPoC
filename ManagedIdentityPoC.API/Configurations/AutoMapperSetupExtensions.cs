using ManagedIdentityPoC.Application.Automapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ManagedIdentityPoC.API.Configurations
{
    public static class AutoMapperSetupExtensions
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToContractMappingProfile), typeof(ContractToDomainMappingProfile));

            AutoMapperConfig.RegisterMappings();
        }
    }
}
