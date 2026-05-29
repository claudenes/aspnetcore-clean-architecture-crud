using Colorado.Domain.Entities;
using Colorado.Domain.Interfaces;
using Colorado.Infra.Data.Context;

namespace Colorado.Infra.Data.Repositories
{
    public class TipoTelefoneRepository : ResourceRepository<TipoTelefone>, ITipoTelefoneRepository
    {
        public TipoTelefoneRepository(ApplicationDbContext context) : base(context) { }
    }
}
