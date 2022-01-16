using Microsoft.EntityFrameworkCore;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using Requisicao_RSS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisicao_RSS.Infra.Data.Repositories
{
    public class RetiradaMaterialRepository : IRetiradaMaterialRepository
    {
        // Injeção de dependência
        private readonly ApplicationDbContext _retiradaMaterialRepository;

        public RetiradaMaterialRepository(ApplicationDbContext context)
        {
            _retiradaMaterialRepository = context;
        }

        // Add retirada
        public async Task<RetiradaMaterial> CreateAsync(RetiradaMaterial retiradaMaterial)
        {
            _retiradaMaterialRepository.Add(retiradaMaterial);
            await _retiradaMaterialRepository.SaveChangesAsync();
            return retiradaMaterial;
        }

        // Get retirada pelo ID
        public async Task<RetiradaMaterial> GetByIdAsync(int? retiradaMaterialId)
        {
            return await _retiradaMaterialRepository.RetiradaMateriais.FindAsync(retiradaMaterialId);
        }

        // Get retirada de um fornecedor específico
        public async Task<RetiradaMaterial> GetRetiradaByFornecedor(int fornecedorId)
        {
            return await _retiradaMaterialRepository.RetiradaMateriais.OrderByDescending(r => r.Data).Include(f => f.Fornecedor)
                .SingleOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }

        // GetAll retiradas
        public async Task<IEnumerable<RetiradaMaterial>> GetRetiradaMateriaisAsync()
        {
            return await _retiradaMaterialRepository.RetiradaMateriais.OrderByDescending(r => r.Data).ToListAsync();
        }

        // Remove retirada
        public async Task<RetiradaMaterial> RemoveAsync(RetiradaMaterial retiradaMaterial)
        {
            _retiradaMaterialRepository.Remove(retiradaMaterial);
            await _retiradaMaterialRepository.SaveChangesAsync();
            return retiradaMaterial;
        }

        // Edit retirada
        public async Task<RetiradaMaterial> UpdateAsync(RetiradaMaterial retiradaMaterial)
        {
            _retiradaMaterialRepository.Update(retiradaMaterial);
            await _retiradaMaterialRepository.SaveChangesAsync();
            return retiradaMaterial;
        }
    }
}
