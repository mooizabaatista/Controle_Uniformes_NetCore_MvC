using Requisicao_RSS.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Interfaces
{
    public interface IRetiradaMaterialService
    {
        Task<IEnumerable<RetiradaMaterialDTO>> GetRetiradasMateriais();
        Task<RetiradaMaterialDTO> GetById(int? id);
        Task<RetiradaMaterialDTO> GetRetiradaFornecedor(int fornecedorId);
        Task Add(RetiradaMaterialDTO retiradaMaterialDTO);
        Task Update(RetiradaMaterialDTO retiradaMaterialDTO);
        Task Remove(int? id);
    }
}
