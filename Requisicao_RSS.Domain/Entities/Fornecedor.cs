using System.Collections.Generic;

namespace Requisicao_RSS.Domain.Entities
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }

        // Relacionamentos
        public virtual IEnumerable<EntregaMaterial> EntregaMateriais { get; set; }
        public virtual IEnumerable<RetiradaMaterial> RetiradaMateriais { get; set; }
    }
}
