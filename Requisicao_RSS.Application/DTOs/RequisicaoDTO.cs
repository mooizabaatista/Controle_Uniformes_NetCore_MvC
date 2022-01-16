using Requisicao_RSS.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Requisicao_RSS.Application.DTOs
{
    public class RequisicaoDTO
    {
        // Id
        public int RequisicaoId { get; set; }

        // Registro
        [Required(ErrorMessage = "Registro Inválido. O Registro é obrigatório.")]
        [MinLength(1, ErrorMessage = "Registro Inválido. O Registro deve conter no mínimo 1 caracteres.")]
        [MaxLength(10, ErrorMessage = "Registro Inválido. O Registro deve conter no máximo 10 caracteres.")]
        public string Registro { get; set; }

        // Data 
        [Required(ErrorMessage = "Data Inválida. Informe uma data correta.")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? Data { get; set; }

        // Tamanho camiseta
        [Required(ErrorMessage = "Tamanho camiseta Inválida. O Tamanho da camiseta é obrigatória.")]
        public string TamanhoCamisa { get; set; }

        // Tamanho calça
        [Required(ErrorMessage = "Tamanho calça Inválida. O Tamanho da calça é obrigatória.")]
        public string TamanhoCalca { get; set; }

        // Quantidade de camisetas
        [Required(ErrorMessage = "Quantidade camiseta Inválida. A Quantidade da camiseta é obrigatória.")]
        public int? QuantidadeCamisa { get; set; }

        // Quantidade de calças
        [Required(ErrorMessage = "Quantidade calça Inválida. A Quantidade da calça é obrigatória.")]
        public int? QuantidadeCalca { get; set; }

        // Quantidade de luvas
        [Required(ErrorMessage = "Quantidade luvas Inválido. A Quantidade da luvas é obrigatório.")]
        public int? QuantidadeLuva { get; set; }

        // Divergencia na entrega
        [Required(ErrorMessage = "Expecifique se houve alguma divergência.")]
        public string Divergencia { get; set; }

        // Observaçoes
        public string Observacoes { get; set; }

        // Relacionamentos
        public Funcionario Funcionario { get; set; }

        [DisplayName("Funcionario")]
        public int FuncionarioId { get; set; }
    }
}
