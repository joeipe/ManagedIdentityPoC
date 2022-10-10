using AutoMapper;
using ManagedIdentityPoC.Contract;
using ManagedIdentityPoC.Integration.TableStorage.Domain;

namespace ManagedIdentityPoC.Application.Automapper
{
    public class ContractToDomainMappingProfile : Profile
    {
        public ContractToDomainMappingProfile()
        {
            CreateMap<PersonDto, PersonEntity>();
        }
    }
}