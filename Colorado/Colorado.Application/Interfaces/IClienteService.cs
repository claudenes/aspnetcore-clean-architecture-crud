using Colorado.Application.Dtos;

namespace Colorado.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDto> Create(ClienteDto cliente);
        Task<ClienteDto> Read(int Id);
        Task<ClienteDto> Update(ClienteDto cliente);
        Task<ClienteDto> Delete(int Id);
        Task<IEnumerable<ClienteDto>> ListAll();

    }
}
