using Microsoft.EntityFrameworkCore;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using Requisicao_RSS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisicao_RSS.Infra.Data.Repositories
{
    public class EntregaMaterialRepository : IEntregaMaterialRepository
    {
        // Injeção de dependência
        private readonly ApplicationDbContext _entregaMaterialRepository;

        public EntregaMaterialRepository(ApplicationDbContext context)
        {
            _entregaMaterialRepository = context;
        }

        // Add entrega
        public async Task<EntregaMaterial> CreateAsync(EntregaMaterial entregaMaterial)
        {
            _entregaMaterialRepository.Add(entregaMaterial);
            await _entregaMaterialRepository.SaveChangesAsync();
            return entregaMaterial;
        }

        // Get entrega pelo ID
        public async Task<EntregaMaterial> GetByIdAsync(int? entregaMaterialId)
        {
            return await _entregaMaterialRepository.EntregaMateriais.FindAsync(entregaMaterialId);
        }

        // Get entrega de um fornecedor específico
        public async Task<EntregaMaterial> GetEntregaByFornecedor(int fornecedorId)
        {
            return await _entregaMaterialRepository.EntregaMateriais.OrderByDescending(r => r.Data).Include(f => f.Fornecedor)
                .SingleOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }

        // GetAll entregas 
        public async Task<IEnumerable<EntregaMaterial>> GetEntregaMateriaisAsync()
        {
            return await _entregaMaterialRepository.EntregaMateriais.OrderByDescending(r => r.Data).ToListAsync();
        }

        // Remove entrega
        public async Task<EntregaMaterial> RemoveAsync(EntregaMaterial entregaMaterial)
        {
            _entregaMaterialRepository.Remove(entregaMaterial);
            await _entregaMaterialRepository.SaveChangesAsync();
            return entregaMaterial;
        }

        // Edit entrega
        public async Task<EntregaMaterial> UpdateAsync(EntregaMaterial entregaMaterial)
        {
            _entregaMaterialRepository.Update(entregaMaterial);
            await _entregaMaterialRepository.SaveChangesAsync();
            return entregaMaterial;
        }
    }
}
