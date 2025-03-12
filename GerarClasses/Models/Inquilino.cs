using System;
using System.Collections.Generic;

namespace ProjetoAbais.DOMAIN.Models;

public partial class Inquilino
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Email { get; set; }

    public string Endereco { get; set; } = null!;

    public virtual ICollection<Aluguel> Aluguels { get; set; } = new List<Aluguel>();
}
