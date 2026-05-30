using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colorado.Domain.Entities
{
    public class Telefone
    {
        [Key]
        public int CodigoCliente { get; set; }
        [Key]
        public string NumeroTelefone { get; set; } = string.Empty;
        public int CodigoTipoTelefone { get; set; }
        public string Operadora { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataInsercao { get; set; } = DateTime.Now;
        public string UsuarioInsercao { get; set; } = string.Empty;

        // Navegação: telefone pertence a um cliente
        public Cliente Cliente { get; set; }

        // Navegação: telefone tem um tipo
        [ForeignKey("CodigoTipoTelefone")]
        public TipoTelefone TipoTelefone { get; set; }
    }
}
