using AutoMapper;
using Colorado.Application.Dtos;
using Colorado.Application.Interfaces;
using Colorado.Domain.Entities;
using Colorado.Domain.Interfaces;

namespace Colorado.Application.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _repository;
        private readonly IMapper _mapper;

        public TelefoneService(ITelefoneRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TelefoneDto> Create(TelefoneDto telefoneDto)
        {
            return _mapper.Map<TelefoneDto>(_repository.Create(_mapper.Map<Telefone>(telefoneDto)));
        }

        public async Task<TelefoneDto> Delete(int Id)
        {
            return _mapper.Map<TelefoneDto>(_repository.Delete(Id));
        }

        public async Task<IEnumerable<TelefoneDto>> ListAll()
        {
            return _mapper.Map<IEnumerable<TelefoneDto>>(_repository.ReadAll());
        }

        public async Task<TelefoneDto> Read(int Id)
        {
            return _mapper.Map<TelefoneDto>(_repository.ReadById(Id));
        }

        public async Task<TelefoneDto> Update(TelefoneDto telefoneDto)
        {
            return _mapper.Map<TelefoneDto>(_repository.Update(_mapper.Map<Telefone>(telefoneDto)));
        }
    }
}
