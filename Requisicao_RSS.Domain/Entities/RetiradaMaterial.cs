using System;

namespace Requisicao_RSS.Domain.Entities
{
    public class RetiradaMaterial
    {
        public int RetiradaMaterialId { get; set; }
        public DateTime? Data { get; set; }
        public string Tipo { get; set; }
        public string NomeFornecedor { get; set; }
        public int QuantidadeCamisas { get; set; }
        public int QuantidadeCalcas { get; set; }
        public int QuantidadeLuvas { get; set; }
        public string Divergencia { get; set; }
        public string Observacoes { get; set; }

        // Relacionamentos
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
