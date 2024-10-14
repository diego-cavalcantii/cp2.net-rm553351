using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class FornecedorDto
    {
        [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatorio")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Campo deve ter no minimo 5 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Cnpj)} é obrigatorio")]
        [RegularExpression(@"\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "O CNPJ deve estar no formato 00.000.000/0000-00")]
        public string Cnpj { get; set; } = string.Empty;

        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Telefone)} é obrigatorio")]
        [Phone(ErrorMessage = "O Telefone não é válido")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Email)} é obrigatorio")]
        [EmailAddress(ErrorMessage = "O Email não é valido")]
        public string Email { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; }
    }
}
