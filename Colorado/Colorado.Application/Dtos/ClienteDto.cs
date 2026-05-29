namespace Colorado.Application.Dtos
{
    public class ClienteDto
    {
        public int CodigoCliente { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string TipoPessoa { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; } = string.Empty;

        // Navegação
        public ICollection<TelefoneDto> Telefones { get; set; } = new List<TelefoneDto>();
    }
}
