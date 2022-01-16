using Requisicao_RSS.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Requisicao_RSS.Application.DTOs
{
    public class RetiradaMaterialDTO
    {
        // Id
        public int RetiradaMaterialId { get; set; }

        // Data da entrega
        [Required(ErrorMessage = "Data Obrigatória. A data é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Data { get; set; }


        // Nome fornecedor
        [Required(ErrorMessage = "Nome Obrigatório. O Nome é obrigatório.")]
        public string NomeFornecedor { get; set; }

        // Tipo de retirada
        [Required(ErrorMessage = "Tipo Inválido. O Tipo é obrigatório.")]
        public string Tipo { get; set; }

        // Quantidade de camisetas
        [Required(ErrorMessage = "Quantidade Camisetas Inválida. A Quantidade de camisas é obrigatória.")]
        public int? QuantidadeCamisas { get; set; }

        // Quantidade de calças
        [Required(ErrorMessage = "Quantidade Calças Inválida. A Quantidade de calças é obrigatória.")]
        public int? QuantidadeCalcas { get; set; }

        // Quantidade de luvas
        [Required(ErrorMessage = "Quantidade Luvas Inválida. A Quantidade de luvas é obrigatória.")]
        public int? QuantidadeLuvas { get; set; }

        // Divergencia na entrega
        [Required(ErrorMessage = "Expecifique se houve alguma divergência.")]
        public string Divergencia { get; set; }

        // Observaçoes
        public string Observacoes { get; set; }

        // Relacionamentos
        [DisplayName("Fornecedor")]
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
