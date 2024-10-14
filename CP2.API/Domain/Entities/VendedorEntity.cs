using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Telefone { get; set; } = string.Empty;
        
        public DateTime DataNascimento { get; set; }
        
        public string Endereco { get; set; } = string.Empty;
        
        public DateTime DataContratacao { get; set; }
        
        public decimal ComissaoPercentual { get; set; }
        
        public decimal MetaMensal { get; set; }
        
        public DateTime CriadoEm { get; set; }
    }
}
