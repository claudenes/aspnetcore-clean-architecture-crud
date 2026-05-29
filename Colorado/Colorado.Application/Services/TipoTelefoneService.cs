using AutoMapper;
using Colorado.Application.Dtos;
using Colorado.Application.Interfaces;
using Colorado.Domain.Entities;
using Colorado.Domain.Interfaces;

namespace Colorado.Application.Services
{
    public class TipoTelefoneService : ITipoTelefoneService
    {
        private readonly ITipoTelefoneRepository _repository;
        private readonly IMapper _mapper;

        public TipoTelefoneService(ITipoTelefoneRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TipoTelefoneDto> Create(TipoTelefoneDto tipoTelefoneDto)
        {
            return _mapper.Map<TipoTelefoneDto>(_repository.Create(_mapper.Map<TipoTelefone>(tipoTelefoneDto)));
        }

        public async Task<TipoTelefoneDto> Delete(int Id)
        {
            return _mapper.Map<TipoTelefoneDto>(_repository.Delete(Id));
        }

        public async Task<IEnumerable<TipoTelefoneDto>> ListAll()
        {
            return _mapper.Map<IEnumerable<TipoTelefoneDto>>(_repository.ReadAll());
        }

        public async Task<TipoTelefoneDto> Read(int Id)
        {
            return _mapper.Map<TipoTelefoneDto>(_repository.ReadById(Id));
        }

        public async Task<TipoTelefoneDto> Update(TipoTelefoneDto tipoTelefoneDto)
        {
            return _mapper.Map<TipoTelefoneDto>(_repository.Update(_mapper.Map<TipoTelefone>(tipoTelefoneDto)));
        }
    }
}
