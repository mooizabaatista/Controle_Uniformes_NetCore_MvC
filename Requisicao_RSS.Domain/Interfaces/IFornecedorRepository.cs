using Requisicao_RSS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> GetFornecedoresAsync();
        Task<Fornecedor> GetByIdAsync(int? fornecedorId);

        Task<Fornecedor> CreateAsync(Fornecedor fornecedor);
        Task<Fornecedor> UpdateAsync(Fornecedor fornecedor);
        Task<Fornecedor> RemoveAsync(Fornecedor fornecedor);
    }
}
