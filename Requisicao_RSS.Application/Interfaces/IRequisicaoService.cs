using Requisicao_RSS.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Interfaces
{
    public interface IRequisicaoService
    {
        Task<IEnumerable<RequisicaoDTO>> GetRequisicoes();
        Task<RequisicaoDTO> GetById(int? id);
        Task<RequisicaoDTO> GetRequisicaoFuncionario(int? funcionarioId);
        Task Add(RequisicaoDTO requisicaoDTO);
        Task Update(RequisicaoDTO requisicaoDTO);
        Task Remove(int? id);
    }
}
 