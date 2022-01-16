using AutoMapper;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using Requisicao_RSS.Domain.Entities;
using Requisicao_RSS.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisicao_RSS.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        // Injeção de dependência
        private IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;

        }

        // Add funcionário
        public async Task Add(FuncionarioDTO funcionarioDto)
        {
            var xFuncionarioEntity = _mapper.Map<Funcionario>(funcionarioDto);
            await _funcionarioRepository.CreateAsync(xFuncionarioEntity);
        }

        // Get funcionário pelo ID
        public async Task<FuncionarioDTO> GetById(int? id)
        {
            var xFuncionarioEntity = await _funcionarioRepository.GetByIdAsync(id);
            return _mapper.Map<FuncionarioDTO>(xFuncionarioEntity);
        }

        // Get funcionário pelo registro
        public async Task<FuncionarioDTO> GetByRegistro(string registro)
        {
            var xFuncionario = await _funcionarioRepository.GetByRegistroAsync(registro);
            return _mapper.Map<FuncionarioDTO>(xFuncionario);
        }

        // GetAll funcionários
        public async Task<IEnumerable<FuncionarioDTO>> GetFuncionarios()
        {
            var xFuncionariosEntity = await _funcionarioRepository.GetFuncionariosAsync();
            return _mapper.Map<IEnumerable<FuncionarioDTO>>(xFuncionariosEntity);

        }

        // Remove funcionário
        public async Task Remove(int? id)
        {
            var xFuncionarioEntity = _funcionarioRepository.GetByIdAsync(id).Result;
            await _funcionarioRepository.RemoveAsync(xFuncionarioEntity);
        }

        // Edit usuário
        public async  Task Update(FuncionarioDTO funcionarioDto)
        {
            var xFuncionarioEntity = _mapper.Map<Funcionario>(funcionarioDto);
            await _funcionarioRepository.UpdateAsync(xFuncionarioEntity);
        }        
    }
}
