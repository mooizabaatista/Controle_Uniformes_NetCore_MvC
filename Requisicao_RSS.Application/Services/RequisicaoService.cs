using AutoMapper;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Services
{
    public class RequisicaoService : IRequisicaoService
    {
        // Injeção de dependência
        private IRequisicaoRepository _requisicaoRepository;
        private readonly IMapper _mapper;

        public RequisicaoService(IRequisicaoRepository requisicaoRepository, IMapper mapper)
        {
            _requisicaoRepository = requisicaoRepository;
            _mapper = mapper;
        }

        // Add requisicao
        public async Task Add(RequisicaoDTO requisicaoDTO)
        {
            var xRequisicaoEntity = _mapper.Map<Requisicao>(requisicaoDTO);
            await _requisicaoRepository.CreateAsync(xRequisicaoEntity);
        }

        // Get requisicao pelo ID
        public async Task<RequisicaoDTO> GetById(int? id)
        {
            var xRequisicaoEntity = await _requisicaoRepository.GetByIdAsync(id) ;
            return _mapper.Map<RequisicaoDTO>(xRequisicaoEntity);
        }

        // Get requisicao de um funcionario específico
        public async Task<RequisicaoDTO> GetRequisicaoFuncionario(int? funcionarioId)
        {
            var xFuncionarioEntity = await _requisicaoRepository.GetRequisicaoFuncionario(funcionarioId);
            return _mapper.Map<RequisicaoDTO>(xFuncionarioEntity);
        }

        // GetAll requisicoes
        public async Task<IEnumerable<RequisicaoDTO>> GetRequisicoes()
        {
            var xRequisicoes = await _requisicaoRepository.GetRequisicoesAsync();
            return _mapper.Map<IEnumerable<RequisicaoDTO>>(xRequisicoes);

        }

        // Remove requisicao
        public async Task Remove(int? id)
        {
            var xRequisicao = _requisicaoRepository.GetByIdAsync(id).Result;
            await _requisicaoRepository.RemoveAsync(xRequisicao);
        }

        // Edit requisicao
        public async Task Update(RequisicaoDTO requisicaoDTO)
        {
            var xRequisicao = _mapper.Map<Requisicao>(requisicaoDTO);
            await _requisicaoRepository.UpdateAsync(xRequisicao);
        }
    }
}
