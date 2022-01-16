using Microsoft.EntityFrameworkCore;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using Requisicao_RSS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisicao_RSS.Infra.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        // Injeção de dependência
        private readonly ApplicationDbContext _funcionarioRepository;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _funcionarioRepository = context;
        }

        // Add funcionário
        public async Task<Funcionario> CreateAsync(Funcionario funcionario)
        {
            _funcionarioRepository.Add(funcionario);
            await _funcionarioRepository.SaveChangesAsync();
            return funcionario;
        }

        // Get funcionário pelo ID
        public async Task<Funcionario> GetByIdAsync(int? funcionarioId)
        {
            return await _funcionarioRepository.Funcionarios.FindAsync(funcionarioId);
        }

        // Get funcionário pelo registro
        public async Task<Funcionario> GetByRegistroAsync(string registro)
        {
            return await _funcionarioRepository.Funcionarios.FirstOrDefaultAsync(c => c.Registro == registro);
        }

        // Get turno funcionario
        public int GetByTurno()
        {
            var count = _funcionarioRepository.Funcionarios.Where(c => c.Turno == "DIURNO").Count();
            return count;
        }
        
        // Get All funcionarios
        public async Task<IEnumerable<Funcionario>> GetFuncionariosAsync()
        {
            return await _funcionarioRepository.Funcionarios.ToListAsync();
        }
  
       
        // Remove funcionario
        public async Task<Funcionario> RemoveAsync(Funcionario funcionario)
        {
            _funcionarioRepository.Remove(funcionario);
            await _funcionarioRepository.SaveChangesAsync();
            return funcionario;
        }

        // Edit funcionario
        public async Task<Funcionario> UpdateAsync(Funcionario funcionario)
        {
            _funcionarioRepository.Update(funcionario);
            await _funcionarioRepository.SaveChangesAsync();
            return funcionario;
        }
    }
}
