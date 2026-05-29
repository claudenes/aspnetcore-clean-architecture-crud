using AutoMapper;
using Colorado.Application.Dtos;
using Colorado.Domain.Entities;

namespace Colorado.Application.Mappings
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<TelefoneDto, Telefone>().ReverseMap();
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<TipoTelefoneDto, TipoTelefone>().ReverseMap();

        }
    }
}
