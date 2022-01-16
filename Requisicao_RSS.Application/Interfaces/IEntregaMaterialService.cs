using Requisicao_RSS.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Interfaces
{
    public interface IEntregaMaterialService
    {
        Task<IEnumerable<EntregaMaterialDTO>> GetEntregasMateriais();
        Task<EntregaMaterialDTO> GetById(int? id);
        Task<EntregaMaterialDTO> GetEntregaFornecedor(int fornecedorId);
        Task Add(EntregaMaterialDTO entregaMaterialDTO);
        Task Update(EntregaMaterialDTO entregaMaterialDTO);
        Task Remove(int? id);
    }
}
