using Requisicao_RSS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDTO>> GetFornecedores();
        Task<FornecedorDTO> GetById(int? id);
        Task Add(FornecedorDTO fornecedorDTO);
        Task Update(FornecedorDTO fornecedorDTO);
        Task Remove(int? id);
    }
}
