using AutoMapper;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Domain.Entities;

namespace Requisicao_RSS.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            // Mapeamento das entidades de dominio com os DTOS ( Data Transfer Object )
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            CreateMap<Requisicao, RequisicaoDTO>().ReverseMap();
            CreateMap<EntregaMaterial, EntregaMaterialDTO>().ReverseMap();
            CreateMap<RetiradaMaterial, RetiradaMaterialDTO>().ReverseMap();
        }
    }
}
