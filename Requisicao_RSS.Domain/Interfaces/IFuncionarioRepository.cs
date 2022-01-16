using Requisicao_RSS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetFuncionariosAsync();
        Task<Funcionario> GetByIdAsync(int? funcionarioId);
        Task<Funcionario> GetByRegistroAsync(string registro);
        Task<Funcionario> CreateAsync(Funcionario funcionario);
        Task<Funcionario> UpdateAsync(Funcionario funcionario);
        Task<Funcionario> RemoveAsync(Funcionario funcionario);
    }
}
