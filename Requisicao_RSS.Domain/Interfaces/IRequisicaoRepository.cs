using Requisicao_RSS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Domain.Interfaces
{
    public interface IRequisicaoRepository
    {
        Task<IEnumerable<Requisicao>> GetRequisicoesAsync();
        Task<Requisicao> GetByIdAsync(int? requisicaoId);
        Task<IEnumerable<Requisicao>> GetRequisicaoFuncionario(int? funcionarioId);
        Task<Requisicao> CreateAsync(Requisicao requisicao);
        Task<Requisicao> UpdateAsync(Requisicao requisicao);
        Task<Requisicao> RemoveAsync(Requisicao requisicao);
    }
}
