﻿using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAbais.API.DTOs
{
    public class AdministradorCadastroDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "O nome deve ter no maximo 255 caracteres")]
        [Unicode(false)]
        public string Nome { get; set; }

        [StringLength(20)]
        [MinLength(11, ErrorMessage = "O telefone deve ter, no mínimo, 11 caracteres")]
        [Unicode(false)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(255)]
        [MinLength(6, ErrorMessage = "A senha deve ter, no mínimo, 6 caracteres.")]
        [Unicode(false)]
        public string Senha { get; set; }
    }
}
