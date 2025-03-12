using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAbais.API.DTOs
{
    public class InquilinoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "O nome deve ter, no máximo, 255 caracteres")]
        [Unicode(false)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        [MinLength(11, ErrorMessage = "O telefone deve ter, no mínimo, 11 caracteres")]
        [Unicode(false)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(20)]
        [MinLength(11, ErrorMessage = "O CPF deve ter, no mínimo, 11 caracteres")]
        [Unicode(false)]
        public string Cpf { get; set; }

        [StringLength(255, ErrorMessage = "O email deve ter, no máximo, 255 caracteres")]
        [Unicode(false)]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "O endereço deve ter no máximo 255 caracteres")]
        [Unicode(false)]
        public string Endereco { get; set; }
    }
}
