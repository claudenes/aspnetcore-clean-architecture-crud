using Colorado.Application.Dtos;

namespace Colorado.Application.Interfaces
{
    public interface ITipoTelefoneService
    {
        Task<TipoTelefoneDto> Create(TipoTelefoneDto tipoTelefone);
        Task<TipoTelefoneDto> Read(int Id);
        Task<TipoTelefoneDto> Update(TipoTelefoneDto tipoTelefone);
        Task<TipoTelefoneDto> Delete(int Id);
        Task<IEnumerable<TipoTelefoneDto>> ListAll();

    }
}
