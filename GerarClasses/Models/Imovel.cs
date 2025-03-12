using System;
using System.Collections.Generic;

namespace ProjetoAbais.DOMAIN.Models;

public partial class Imovel
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public virtual ICollection<Aluguel> Aluguels { get; set; } = new List<Aluguel>();
}
