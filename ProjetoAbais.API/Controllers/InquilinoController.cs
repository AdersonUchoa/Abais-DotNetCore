using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoAbais.API.DTOs;
using ProjetoAbais.API.Interfaces;
using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquilinoController : Controller
    {
        private readonly InquilinoInterfaceRepository _inquilinoInterfaceRepository;
        private readonly IMapper _mapper;

        public InquilinoController(InquilinoInterfaceRepository inquilinoInterfaceRepository, IMapper mapper)
        {
            _inquilinoInterfaceRepository = inquilinoInterfaceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquilino>>> GetAllInquilinos()
        {
            var inquilinos = await _inquilinoInterfaceRepository.GetAllInquilinos();
            var inquilinosDTO = _mapper.Map<IEnumerable<InquilinoDTO>>(inquilinos);
            return Ok(inquilinosDTO); //"Ok" = codigo 200 = requisição bem sucedida
        }

        [HttpPost]
        public async Task<ActionResult> PostInquilino(InquilinoDTO inquilinoDTO)
        {
            var inquilino = _mapper.Map<Inquilino>(inquilinoDTO);
            _inquilinoInterfaceRepository.PostInquilino(inquilino);
            if(await _inquilinoInterfaceRepository.SaveAllAsync())
            {
                return Ok("Inquilino cadastrado com sucesso.");
            }

            return BadRequest("Erro ao cadastrar inquilino.");
        }

        [HttpPut]
        public async Task<ActionResult> PutInquilino(InquilinoDTO inquilinoDTO)
        {
            var inquilinoExiste = await _inquilinoInterfaceRepository.GetInquilinoById(inquilinoDTO.Id);
            if (inquilinoExiste == null)
            {
                return NotFound("Inquilino não encontrado.");
            }

            var inquilino = _mapper.Map<Inquilino>(inquilinoDTO);
            _inquilinoInterfaceRepository.PutInquilino(inquilino);
            if (await _inquilinoInterfaceRepository.SaveAllAsync())
            {
                return Ok("Inquilino atualizado com sucesso.");
            }
            return BadRequest("Erro ao atualizar inquilino.");
        }

        [HttpDelete("{inquilinoId}")]
        public async Task<ActionResult> DeleteInquilino(int inquilinoId)
        {
            var inquilino = await _inquilinoInterfaceRepository.GetInquilinoById(inquilinoId);

            if(inquilino == null)
            {
                return NotFound("Inquilino não encontrado.");
            }

            _inquilinoInterfaceRepository.DeleteInquilino(inquilino);

            if (await _inquilinoInterfaceRepository.SaveAllAsync())
            {
                return Ok("Inquilino deletado com sucesso.");
            }
            return BadRequest("Erro ao deletar inquilino.");
        }

        [HttpGet("{inquilinoId}")]
        public async Task<ActionResult> GetInquilinoById(int inquilinoId)
        {
            var inquilino = await _inquilinoInterfaceRepository.GetInquilinoById(inquilinoId);
            if (inquilino == null)
            {
                return NotFound("Inquilino não encontrado.");
            }

            var inquilinoDTO = _mapper.Map<InquilinoDTO>(inquilino);

            return Ok(inquilinoDTO);
        }
    }
}
