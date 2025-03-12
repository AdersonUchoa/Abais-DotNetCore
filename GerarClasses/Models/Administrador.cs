using System;
using System.Collections.Generic;

namespace ProjetoAbais.DOMAIN.Models;

public partial class Administrador
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Telefone { get; set; }

    public string Senha { get; set; } = null!;

    public virtual ICollection<Aluguel> Aluguels { get; set; } = new List<Aluguel>();
}
