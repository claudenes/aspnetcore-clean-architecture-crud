using Colorado.Domain.Entities;
using Colorado.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Colorado.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoTelefone> TipoTelefones { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Telefone>(new TelefoneMap().Configure);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<TipoTelefone>(new TipoTelefoneMap().Configure);

        }
    }
}
