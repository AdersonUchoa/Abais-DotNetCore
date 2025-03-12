using AutoMapper;
using ProjetoAbais.API.DTOs;
using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Mappings
{
    public class EntityToDTOsMappingProfile : Profile
    {
        public EntityToDTOsMappingProfile()
        {
            CreateMap<Inquilino, InquilinoDTO>().ReverseMap();
            CreateMap<Aluguel, AluguelDTO>().ReverseMap();
            CreateMap<Imovel, ImovelDTO>().ReverseMap();
            CreateMap<Administrador, AdministradorDTO>().ReverseMap();
            CreateMap<Administrador, AdministradorCadastroDTO>().ReverseMap();
        }
    }
}
