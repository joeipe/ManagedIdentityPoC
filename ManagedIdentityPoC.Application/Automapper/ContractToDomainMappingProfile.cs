using AutoMapper;
using ManagedIdentityPoC.Contract;
using ManagedIdentityPoC.Data.Domain;
using ManagedIdentityPoC.Integration.TableStorage.Domain;

namespace ManagedIdentityPoC.Application.Automapper
{
    public class ContractToDomainMappingProfile : Profile
    {
        public ContractToDomainMappingProfile()
        {
            CreateMap<PersonDto, PersonEntity>();
            CreateMap<CountryDto, CountryEntity>();
        }
    }
}