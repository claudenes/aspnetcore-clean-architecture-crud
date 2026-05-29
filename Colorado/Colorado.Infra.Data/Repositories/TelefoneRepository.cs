using Colorado.Domain.Entities;
using Colorado.Domain.Interfaces;
using Colorado.Infra.Data.Context;

namespace Colorado.Infra.Data.Repositories
{
    public class TelefoneRepository : ResourceRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(ApplicationDbContext context) : base(context) { }
    }
}
