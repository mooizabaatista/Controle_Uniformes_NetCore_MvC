using AutoMapper;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Services
{
    public class RetiradaMaterialService : IRetiradaMaterialService
    {
        // Injecão de dependência
        private IRetiradaMaterialRepository _retiradaMaterialRepository;
        private readonly IMapper _mapper;

        public RetiradaMaterialService(IRetiradaMaterialRepository retiradaMaterialRepository, IMapper mapper)
        {
            _retiradaMaterialRepository = retiradaMaterialRepository;
            _mapper = mapper;
        }

        // Add retirada
        public async Task Add(RetiradaMaterialDTO retiradaMaterialDTO)
        {
            var xRetiradaMaterialEntity = _mapper.Map<RetiradaMaterial>(retiradaMaterialDTO);
            await _retiradaMaterialRepository.CreateAsync(xRetiradaMaterialEntity);
        }

        // Get retirada pelo ID
        public async Task<RetiradaMaterialDTO> GetById(int? id)
        {
            var xRetiradaMaterial = await _retiradaMaterialRepository.GetByIdAsync(id);
            return _mapper.Map<RetiradaMaterialDTO>(xRetiradaMaterial);
        }

        // Get retirada de um fornecedor em específico
        public async Task<RetiradaMaterialDTO> GetRetiradaFornecedor(int fornecedorId)
        {
            var xRetiradaFornecedor = await _retiradaMaterialRepository.GetRetiradaByFornecedor(fornecedorId);
            return _mapper.Map<RetiradaMaterialDTO>(xRetiradaFornecedor);
        }

        // GetAll retiradas
        public async Task<IEnumerable<RetiradaMaterialDTO>> GetRetiradasMateriais()
        {
            var xRetiradaMateriais = await _retiradaMaterialRepository.GetRetiradaMateriaisAsync();
            return _mapper.Map<IEnumerable<RetiradaMaterialDTO>>(xRetiradaMateriais);
        }

        // Remove retirada
        public async Task Remove(int? id)
        {
            var xRetiradaMaterialEntity = _retiradaMaterialRepository.GetByIdAsync(id).Result;
            await _retiradaMaterialRepository.RemoveAsync(xRetiradaMaterialEntity);
        }

        // Edit retirada
        public async Task Update(RetiradaMaterialDTO retiradaMaterialDTO)
        {
            var xRetiradaMaterialEntity = _mapper.Map<RetiradaMaterial>(retiradaMaterialDTO);
            await _retiradaMaterialRepository.UpdateAsync(xRetiradaMaterialEntity);
        }
    }
}
