namespace Colorado.Domain.Entities
{
    public class TipoTelefone
    {
        public int CodigoTipoTelefone { get; set; }
        public string DescricaoTipoTelefone { get; set; } = string.Empty;
        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; } = string.Empty;

        // Navegação
        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
