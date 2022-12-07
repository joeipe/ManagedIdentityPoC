using AutoMapper;
using ManagedIdentityPoC.Contract;
using ManagedIdentityPoC.Data.Domain;
using ManagedIdentityPoC.Integration.TableStorage.Domain;

namespace ManagedIdentityPoC.Application.Automapper
{
    public class DomainToContractMappingProfile : Profile
    {
        public DomainToContractMappingProfile()
        {
            CreateMap<PersonEntity, PersonDto>();
            CreateMap<CountryEntity, CountryDto>();
        }
    }
}