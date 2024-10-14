using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("tb_fornecedor")]
    public class FornecedorEntity
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Cnpj { get; set; } = string.Empty;
        
        public string Endereco { get; set; } = string.Empty;
        
        [Required]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; }

    }
}
