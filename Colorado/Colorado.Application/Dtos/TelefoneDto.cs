namespace Colorado.Application.Dtos
{
    public class TelefoneDto
    {
        public int CodigoCliente { get; set; }
        public string NumeroTelefone { get; set; } = string.Empty;
        public int CodigoTipoTelefone { get; set; }
        public string Operadora { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; } = string.Empty;

        // Navegação
        public ClienteDto Cliente { get; set; } =null!;
        public TipoTelefoneDto TipoTelefone { get; set; } = null!;
    }
}
