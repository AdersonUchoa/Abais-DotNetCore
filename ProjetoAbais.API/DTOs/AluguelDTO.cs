using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAbais.API.DTOs
{
    public class AluguelDTO
    {
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int Valor { get; set; }

        public int InquilinoId { get; set; }

        public int AdministradorId { get; set; }
        public int ImovelId { get; set; }
    }
}
