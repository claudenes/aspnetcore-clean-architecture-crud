namespace Colorado.Domain.Entities
{
    public class Telefone
    {
        public int CodigoCliente { get; set; }
        public string NumeroTelefone { get; set; } = string.Empty;
        public int CodigoTipoTelefone { get; set; }
        public string Operadora { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; } = string.Empty;

        // Navegação
        public Cliente Cliente { get; set; } =null!;
        public TipoTelefone TipoTelefone { get; set; } = null!;
    }
}
