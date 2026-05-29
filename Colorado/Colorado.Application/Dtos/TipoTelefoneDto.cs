namespace Colorado.Application.Dtos
{
    public class TipoTelefoneDto
    {
  
        public int CodigoTipoTelefone { get; set; }
        public string DescricaoTipoTelefone { get; set; } = string.Empty;
        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; } = string.Empty;

        // Navegação
        public ICollection<TelefoneDto> Telefones { get; set; } = new List<TelefoneDto>();
    }
}
