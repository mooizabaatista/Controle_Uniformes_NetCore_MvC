using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Requisicao_RSS.Domain.Entities
{
    public class Requisicao
    {
        public int RequisicaoId { get; set; }
        public string Registro { get; set; }

        //[Required, Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        //[DataType("Date")]
        public DateTime? Data { get; set; }     
        public string TamanhoCamisa { get; set; }
        public string TamanhoCalca { get; set; }
        public int QuantidadeCamisa { get; set; }
        public int QuantidadeCalca { get; set; }
        public int QuantidadeLuva { get; set; }
        public string Divergencia { get; set; } 
        public string Observacoes { get; set; }

        // Relacionamentos
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }

    }
}
