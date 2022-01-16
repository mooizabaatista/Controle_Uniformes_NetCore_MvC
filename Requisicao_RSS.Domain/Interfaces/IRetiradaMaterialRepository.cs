using Requisicao_RSS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Domain.Interfaces
{
    public interface IRetiradaMaterialRepository
    {
        Task<IEnumerable<RetiradaMaterial>> GetRetiradaMateriaisAsync();
        Task<RetiradaMaterial> GetByIdAsync(int? retiradaMaterialId);
        Task<RetiradaMaterial> GetRetiradaByFornecedor(int fornecedorId);

        Task<RetiradaMaterial> CreateAsync(RetiradaMaterial retiradaMaterial);
        Task<RetiradaMaterial> UpdateAsync(RetiradaMaterial retiradaMaterial);
        Task<RetiradaMaterial> RemoveAsync(RetiradaMaterial retiradaMaterial);
    }
}
