using Microsoft.EntityFrameworkCore;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using Requisicao_RSS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisicao_RSS.Infra.Data.Repositories
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        // Injeção de dependência
        private readonly ApplicationDbContext _requisicaoRepository;
        public RequisicaoRepository(ApplicationDbContext context)
        {
            _requisicaoRepository = context;
        }

        // Add requisicao
        public async Task<Requisicao> CreateAsync(Requisicao requisicao)
        {
            _requisicaoRepository.Add(requisicao);
            await _requisicaoRepository.SaveChangesAsync();
            return requisicao;
        }

        // Get requisicao pelo ID
        public async Task<Requisicao> GetByIdAsync(int? requisicaoId)
        {
            return await _requisicaoRepository.Requisicoes.OrderByDescending(r => r.Data).SingleOrDefaultAsync(x => x.RequisicaoId == requisicaoId);
        }

        // Get requisicao de um funcionário específico
        public async Task<IEnumerable<Requisicao>> GetRequisicaoFuncionario(int? funcionarioId)
        {
            return await _requisicaoRepository.Requisicoes.OrderByDescending(r => r.Data).Where(x => x.FuncionarioId == funcionarioId).ToListAsync();
        }

        // GetAll requisicoes
        public async Task<IEnumerable<Requisicao>> GetRequisicoesAsync()
        {
            return await _requisicaoRepository.Requisicoes.OrderByDescending(r => r.Data).Include(f => f.Funcionario).ToListAsync();
        }
        
        // Remove requisicao
        public async Task<Requisicao> RemoveAsync(Requisicao requisicao)
        {
            _requisicaoRepository.Remove(requisicao);
            await _requisicaoRepository.SaveChangesAsync();
            return requisicao;
        }

        // Edit requisicao
        public async Task<Requisicao> UpdateAsync(Requisicao requisicao)
        {
            _requisicaoRepository.Update(requisicao);
            await _requisicaoRepository.SaveChangesAsync();
            return requisicao;
        }

        
    }
}
