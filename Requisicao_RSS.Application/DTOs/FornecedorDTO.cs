using System.ComponentModel.DataAnnotations;

namespace Requisicao_RSS.Application.DTOs
{
    public class FornecedorDTO
    {
        // Id
        public int FornecedorId { get; set; }

        // Nome 
        [Required(ErrorMessage = "Nome Inválido. O Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "Nome Inválido. O Nome deve conter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome Inválido. O Nome deve conter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        // Telefone
        [Required(ErrorMessage = "Telefone Inválido. O Telefone é obrigatório.")]
        [MaxLength(13, ErrorMessage = "Telefone Inválido. O Telefone deve conter no máximo 14 caracteres.")]
        public string Telefone { get; set; }

        // Cnpj
        [Required(ErrorMessage = "CNPJ Inválido. O CNPJ é obrigatório.")]
        [MaxLength(18, ErrorMessage = "CNPJ Inválido. O Telefone deve conter no máximo 18 caracteres.")]
        public string CNPJ { get; set; }
    }
}
