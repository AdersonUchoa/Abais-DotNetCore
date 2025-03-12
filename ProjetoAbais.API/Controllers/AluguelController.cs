using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoAbais.API.DTOs;
using ProjetoAbais.API.Interfaces;
using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : Controller
    {
        private readonly AluguelInterfaceRepository _aluguelInterfaceRepository;
        private readonly IMapper _mapper;

        public AluguelController(AluguelInterfaceRepository aluguelInterfaceRepository, IMapper mapper)
        {
            _aluguelInterfaceRepository = aluguelInterfaceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAllAlugueis()
        {
            var alugueis = await _aluguelInterfaceRepository.GetAllAlugueis();
            var alugueisDTO = _mapper.Map<IEnumerable<AluguelDTO>>(alugueis);
            return Ok(alugueisDTO); //"Ok" = codigo 200 = requisição bem sucedida
        }

        [HttpPost]
        public async Task<ActionResult> PostAluguel(AluguelDTO aluguelDTO)
        {
            var aluguel = _mapper.Map<Aluguel>(aluguelDTO);
            _aluguelInterfaceRepository.PostAluguel(aluguel);
            if (await _aluguelInterfaceRepository.SaveAllAsync())
            {
                return Ok("Aluguel cadastrado com sucesso.");
            }
            return BadRequest("Erro ao cadastrar aluguel.");
        }

        [HttpPut]
        public async Task<ActionResult> PutAluguel(AluguelDTO aluguelDTO)
        {
            var aluguelExiste = await _aluguelInterfaceRepository.GetAluguelById(aluguelDTO.Id);
            if (aluguelExiste == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            var aluguel = _mapper.Map<Aluguel>(aluguelDTO);
            _aluguelInterfaceRepository.PutAluguel(aluguel);
            if (await _aluguelInterfaceRepository.SaveAllAsync())
            {
                return Ok("Aluguel atualizado com sucesso.");
            }
            return BadRequest("Erro ao atualizar aluguel.");
        }

        [HttpDelete("{aluguelId}")]
        public async Task<ActionResult> DeleteAluguel(int aluguelId)
        {
            var aluguel = await _aluguelInterfaceRepository.GetAluguelById(aluguelId);
            if (aluguel == null)
            {
                return NotFound("Aluguel não encontrado.");
            }
            _aluguelInterfaceRepository.DeleteAluguel(aluguel);
            if (await _aluguelInterfaceRepository.SaveAllAsync())
            {
                return Ok("Aluguel excluído com sucesso.");
            }
            return BadRequest("Erro ao excluir aluguel.");
        }

        [HttpGet("{aluguelId}")]
        public async Task<ActionResult<Aluguel>> GetAluguelById(int aluguelId)
        {
            var aluguel = await _aluguelInterfaceRepository.GetAluguelById(aluguelId);
            if (aluguel == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            var aluguelDTO = _mapper.Map<AluguelDTO>(aluguel);
            return Ok(aluguelDTO);
        }
    }
}
