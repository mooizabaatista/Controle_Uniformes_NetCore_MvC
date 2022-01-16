using AutoMapper;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        // Injeção de dependência
        private IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        // Add fornecedor
        public async Task Add(FornecedorDTO fornecedorDTO)
        {
            var xFornecedorEntity = _mapper.Map<Fornecedor>(fornecedorDTO);
            await _fornecedorRepository.CreateAsync(xFornecedorEntity);
        }

        // Get fornecedor pelo ID
        public async Task<FornecedorDTO> GetById(int? id)
        {
            var xFornecedorEntity = await _fornecedorRepository.GetByIdAsync(id);
            return _mapper.Map<FornecedorDTO>(xFornecedorEntity);
        }

        // GetAll fornecedores
        public async Task<IEnumerable<FornecedorDTO>> GetFornecedores()
        {
            var xFornecedorEntity = await _fornecedorRepository.GetFornecedoresAsync();
            return _mapper.Map<IEnumerable<FornecedorDTO>>(xFornecedorEntity);
        }

        // Remove fornecedor
        public async Task Remove(int? id)
        {
            var xFornecedorEntity = _fornecedorRepository.GetByIdAsync(id).Result;
            await _fornecedorRepository.RemoveAsync(xFornecedorEntity);
        }

        // Edit fornecedor
        public async Task Update(FornecedorDTO fornecedorDto)
        {
            var xFornecedorEntity = _mapper.Map<Fornecedor>(fornecedorDto);
            await _fornecedorRepository.UpdateAsync(xFornecedorEntity);
        }
    }
}
