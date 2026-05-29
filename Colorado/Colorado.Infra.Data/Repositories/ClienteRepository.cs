using Colorado.Domain.Entities;
using Colorado.Domain.Interfaces;
using Colorado.Infra.Data.Context;

namespace Colorado.Infra.Data.Repositories
{
    public class ClienteRepository : ResourceRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context) { }
    }
}
