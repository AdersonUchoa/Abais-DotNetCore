using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoAbais.API.DTOs;
using ProjetoAbais.API.Interfaces;
using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : Controller
    {
        private readonly ImovelInterfaceRepository _imovelInterfaceRepository;
        private readonly IMapper _mapper;

        public ImovelController(ImovelInterfaceRepository imovelInterfaceRepository, IMapper mapper)
        {
            _imovelInterfaceRepository = imovelInterfaceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imovel>>> GetAllImoveis()
        {
            var imoveis = await _imovelInterfaceRepository.GetAllImoveis();
            var imoveisDTO = _mapper.Map<IEnumerable<ImovelDTO>>(imoveis);
            return Ok(imoveisDTO); //"Ok" = codigo 200 = requisição bem sucedida
        }

        [HttpPost]
        public async Task<ActionResult> PostImovel(ImovelDTO imovelDTO)
        {
            var imovel = _mapper.Map<Imovel>(imovelDTO);
            _imovelInterfaceRepository.PostImovel(imovel);
            if (await _imovelInterfaceRepository.SaveAllAsync())
            {
                return Ok("Imóvel cadastrado com sucesso.");
            }
            return BadRequest("Erro ao cadastrar imóvel.");
        }

        [HttpPut]
        public async Task<ActionResult> PutImovel(ImovelDTO imovelDTO)
        {
            var imovelExiste = await _imovelInterfaceRepository.GetImovelById(imovelDTO.Id);
            if (imovelExiste == null)
            {
                return NotFound("Imóvel não encontrado.");
            }

            var imovel = _mapper.Map<Imovel>(imovelDTO);
            _imovelInterfaceRepository.PutImovel(imovel);
            if (await _imovelInterfaceRepository.SaveAllAsync())
            {
                return Ok("Imóvel atualizado com sucesso.");
            }
            return BadRequest("Erro ao atualizar imóvel.");
        }

        [HttpDelete("{imovelId}")]
        public async Task<ActionResult> DeleteImovel(int imovelId)
        {
            var imovel = await _imovelInterfaceRepository.GetImovelById(imovelId);
            if (imovel == null)
            {
                return NotFound("Imóvel não encontrado.");
            }
            _imovelInterfaceRepository.DeleteImovel(imovel);
            if (await _imovelInterfaceRepository.SaveAllAsync())
            {
                return Ok("Imóvel excluído com sucesso.");
            }
            return BadRequest("Erro ao excluir imóvel.");
        }

        [HttpGet("{imovelId}")]
        public async Task<ActionResult<Imovel>> GetImovelById(int imovelId)
        {
            var imovel = await _imovelInterfaceRepository.GetImovelById(imovelId);
            if (imovel == null)
            {
                return NotFound("Imóvel não encontrado.");
            }

            var imovelDTO = _mapper.Map<ImovelDTO>(imovel);
            return Ok(imovelDTO);
        }
    }
}
