using Requisicao_RSS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Domain.Interfaces
{
    public interface IEntregaMaterialRepository
    {
        Task<IEnumerable<EntregaMaterial>> GetEntregaMateriaisAsync();
        Task<EntregaMaterial> GetByIdAsync(int? entregaMaterialId);

        Task<EntregaMaterial> GetEntregaByFornecedor(int fornecedorId);

        Task<EntregaMaterial> CreateAsync(EntregaMaterial entregaMaterial);
        Task<EntregaMaterial> UpdateAsync(EntregaMaterial entregaMaterial);
        Task<EntregaMaterial> RemoveAsync(EntregaMaterial entregaMaterial);
    }
}
