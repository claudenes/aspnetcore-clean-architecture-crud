using AutoMapper;
using Colorado.Application.Dtos;
using Colorado.Application.Interfaces;
using Colorado.Domain.Entities;
using Colorado.Domain.Interfaces;

namespace Colorado.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> Create(ClienteDto clienteDto)
        {
            return _mapper.Map<ClienteDto>(_repository.Create(_mapper.Map<Cliente>(clienteDto)));
        }

        public async Task<ClienteDto> Delete(int Id)
        {
            return _mapper.Map<ClienteDto>(_repository.Delete(Id));
        }

        public async Task<IEnumerable<ClienteDto>> ListAll()
        {
            return _mapper.Map<IEnumerable<ClienteDto>>(_repository.ReadAll());
        }

        public async Task<ClienteDto> Read(int Id)
        {
            return _mapper.Map<ClienteDto>(_repository.ReadById(Id));
        }

        public async Task<ClienteDto> Update(ClienteDto clienteDto)
        {
            return _mapper.Map<ClienteDto>(_repository.Update(_mapper.Map<Cliente>(clienteDto)));
        }
    }
}
