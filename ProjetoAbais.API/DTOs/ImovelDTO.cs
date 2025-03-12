using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAbais.API.DTOs
{
    public class ImovelDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "O nome deve ter, no máximo, 20 caracteres")]
        [Unicode(false)]
        public string Nome { get; set; }

        [Required]
        [Unicode(false)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O endereço deve ter, no maximo, 50 caracteres")]
        [Unicode(false)]
        public string Endereco { get; set; }
    }
}
