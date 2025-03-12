using System;
using System.Collections.Generic;

namespace ProjetoAbais.DOMAIN.Models;

public partial class Aluguel
{
    public int Id { get; set; }

    public DateOnly DataInicio { get; set; }

    public DateOnly? DataFim { get; set; }

    public int Valor { get; set; }

    public string? Pagamento { get; set; }

    public int InquilinoId { get; set; }

    public int AdministradorId { get; set; }

    public int ImovelId { get; set; }

    public virtual Administrador Administrador { get; set; } = null!;

    public virtual Imovel Imovel { get; set; } = null!;

    public virtual Inquilino Inquilino { get; set; } = null!;
}
