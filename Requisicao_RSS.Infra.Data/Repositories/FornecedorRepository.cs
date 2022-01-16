using Microsoft.EntityFrameworkCore;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using Requisicao_RSS.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Infra.Data.Repositories
{

    public class FornecedorRepository : IFornecedorRepository
    {
        // Injeção de dependência
        private readonly ApplicationDbContext _fornecedorRepository;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _fornecedorRepository = context;
        }

        // Add fornecedor
        public async Task<Fornecedor> CreateAsync(Fornecedor fornecedor)
        {
            _fornecedorRepository.Add(fornecedor);
            await _fornecedorRepository.SaveChangesAsync();
            return fornecedor;
        }
        
        // Get fornecedor pelo ID
        public async Task<Fornecedor> GetByIdAsync(int? fornecedorId)
        {
            return await _fornecedorRepository.Fornecedores.FindAsync(fornecedorId);
        }

        // GetAll fornecedores
        public async Task<IEnumerable<Fornecedor>> GetFornecedoresAsync()
        {
            return await _fornecedorRepository.Fornecedores.ToListAsync();
        }

        // Remove fornecedor
        public async Task<Fornecedor> RemoveAsync(Fornecedor fornecedor)
        {
            _fornecedorRepository.Remove(fornecedor);
            await _fornecedorRepository.SaveChangesAsync();
            return fornecedor;
        }

        // Edit fornecedor
        public async Task<Fornecedor> UpdateAsync(Fornecedor fornecedor)
        {
            _fornecedorRepository.Update(fornecedor);
            await _fornecedorRepository.SaveChangesAsync();
            return fornecedor;
        }
    }
}
