using AutoMapper;

namespace ManagedIdentityPoC.Application.Automapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToContractMappingProfile());
                cfg.AddProfile(new ContractToDomainMappingProfile());
            });
        }
    }
}