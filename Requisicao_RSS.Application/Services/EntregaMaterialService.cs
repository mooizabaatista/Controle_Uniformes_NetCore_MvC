using AutoMapper;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Services
{
    public class EntregaMaterialService : IEntregaMaterialService
    {
        // Injeção de dependência
        private IEntregaMaterialRepository _entregaMaterialRepository;
        private readonly IMapper _mapper;

        public EntregaMaterialService(IEntregaMaterialRepository entregaMaterialRepository, IMapper mapper)
        {
            _entregaMaterialRepository = entregaMaterialRepository;
            _mapper = mapper;
        }

        // Add entrega
        public async Task Add(EntregaMaterialDTO entregaMaterialDTO)
        {
            var xEntregaMaterialEntity = _mapper.Map<EntregaMaterial>(entregaMaterialDTO);
            await _entregaMaterialRepository.CreateAsync(xEntregaMaterialEntity);
        }

        // Get entrega pelo ID
        public async Task<EntregaMaterialDTO> GetById(int? id)
        {
            var xEntregaMaterial = await _entregaMaterialRepository.GetByIdAsync(id);
            return _mapper.Map<EntregaMaterialDTO>(xEntregaMaterial);
        }

        // Get entrega de um fornecedor específico
        public async Task<EntregaMaterialDTO> GetEntregaFornecedor(int fornecedorId)
        {
            var xEntregaFornecedor = await _entregaMaterialRepository.GetEntregaByFornecedor(fornecedorId);
            return _mapper.Map<EntregaMaterialDTO>(xEntregaFornecedor);
        }

        // GetAll entregas
        public async Task<IEnumerable<EntregaMaterialDTO>> GetEntregasMateriais()
        {
            var xEntregasMateriais = await _entregaMaterialRepository.GetEntregaMateriaisAsync();
            return _mapper.Map<IEnumerable<EntregaMaterialDTO>>(xEntregasMateriais);
        }

        // Remove entrega
        public async Task Remove(int? id)
        {
            var xEntregaMaterialEntity = _entregaMaterialRepository.GetByIdAsync(id).Result;
            await _entregaMaterialRepository.RemoveAsync(xEntregaMaterialEntity);
        }

        // Edit entrega
        public async Task Update(EntregaMaterialDTO entregaMaterialDTO)
        {
            var xEntregaMaterialEntity = _mapper.Map<EntregaMaterial>(entregaMaterialDTO);
            await _entregaMaterialRepository.UpdateAsync(xEntregaMaterialEntity);
        }
    }
}
