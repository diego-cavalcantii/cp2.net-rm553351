using System;
using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class VendedorDto
    {
        [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatorio")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Campo deve ter no mínimo 5 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Email)} é obrigatorio")]
        [EmailAddress(ErrorMessage = "O Email não é válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Telefone)} é obrigatorio")]
        [Phone(ErrorMessage = "O Telefone não é válido")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(DataNascimento)} é obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "Data de Nascimento inválida")]
        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(DataContratacao)} é obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "Data de Contratação inválida")]
        public DateTime DataContratacao { get; set; }

        [Range(0, 100, ErrorMessage = "A comissão deve ser entre 0 e 100")]
        public decimal ComissaoPercentual { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(MetaMensal)} é obrigatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "A Meta Mensal deve ser um valor positivo")]
        public decimal MetaMensal { get; set; }
    }
}