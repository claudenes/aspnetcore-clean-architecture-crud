using AutoMapper;
using Colorado.Application.Dtos;
using Colorado.Domain.Entities;

namespace Colorado.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Telefone, TelefoneDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<TipoTelefone, TipoTelefoneDto>().ReverseMap();
        }
    }
}
