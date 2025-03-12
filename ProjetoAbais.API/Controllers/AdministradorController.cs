using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoAbais.API.DTOs;
using ProjetoAbais.API.Interfaces;
using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : Controller
    {
        private readonly AdministradorInterfaceRepository _administradorInterfaceRepository;
        private readonly IMapper _mapper;

        public AdministradorController(AdministradorInterfaceRepository administradorInterfaceRepository, IMapper mapper)
        {
            _administradorInterfaceRepository = administradorInterfaceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAllAdministradores()
        {
            var administradores = await _administradorInterfaceRepository.GetAllAdministradores();
            var administradoresDTO = _mapper.Map<IEnumerable<AdministradorDTO>>(administradores);
            return Ok(administradoresDTO); //"Ok" = codigo 200 = requisição bem sucedida
        }

        [HttpPost]
        public async Task<ActionResult> PostAdministrador(AdministradorCadastroDTO administradorCadastroDTO)
        {
            var administrador = _mapper.Map<Administrador>(administradorCadastroDTO);
            _administradorInterfaceRepository.PostAdministrador(administrador);
            if (await _administradorInterfaceRepository.SaveAllAsync())
            {
                return Ok("Administrador cadastrado com sucesso.");
            }
            return BadRequest("Erro ao cadastrar administrador.");
        }

        [HttpPut]
        public async Task<ActionResult> PutAdministrador(AdministradorCadastroDTO administradorDTO)
        {
            var adminExiste = await _administradorInterfaceRepository.GetAdministradorById(administradorDTO.Id);
            if (adminExiste == null)
            {
                return NotFound("Administrador não encontrado.");
            }

            var administrador = _mapper.Map<Administrador>(administradorDTO);
            _administradorInterfaceRepository.PutAdministrador(administrador);
            if (await _administradorInterfaceRepository.SaveAllAsync())
            {
                return Ok("Administrador atualizado com sucesso.");
            }
            return BadRequest("Erro ao atualizar administrador.");
        }

        [HttpDelete("{administradorId}")]
        public async Task<ActionResult> DeleteAdministrador(int administradorId)
        {
            var administrador = await _administradorInterfaceRepository.GetAdministradorById(administradorId);
            if (administrador == null)
            {
                return NotFound("Administrador não encontrado.");
            }
            _administradorInterfaceRepository.DeleteAdministrador(administrador);
            if (await _administradorInterfaceRepository.SaveAllAsync())
            {
                return Ok("Administrador excluído com sucesso.");
            }
            return BadRequest("Erro ao excluir administrador.");
        }

        [HttpGet("{administradorId}")]
        public async Task<ActionResult<Administrador>> GetAdministradorById(int administradorId)
        {
            var administrador = await _administradorInterfaceRepository.GetAdministradorById(administradorId);
            if (administrador == null)
            {
                return NotFound("Administrador não encontrado.");
            }

            var administradorDTO = _mapper.Map<AdministradorDTO>(administrador);
            return Ok(administradorDTO);
        }
    }
}
