using Colorado.Application.Dtos;

namespace Colorado.Application.Interfaces
{
    public interface ITelefoneService
    {
        Task<TelefoneDto> Create(TelefoneDto telefone);
        Task<TelefoneDto> Read(int Id);
        Task<TelefoneDto> Update(TelefoneDto telefone);
        Task<TelefoneDto> Delete(int Id);
        Task<IEnumerable<TelefoneDto>> ListAll();

    }
}
