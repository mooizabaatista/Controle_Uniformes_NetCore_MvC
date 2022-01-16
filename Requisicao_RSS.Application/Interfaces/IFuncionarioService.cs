using Requisicao_RSS.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioDTO>> GetFuncionarios();
        Task<FuncionarioDTO> GetById(int? id);
        Task<FuncionarioDTO> GetByRegistro(string registro);
        Task Add(FuncionarioDTO funcionarioDto);
        Task Update(FuncionarioDTO funcionarioDto);
        Task Remove(int? id);
    }
}

