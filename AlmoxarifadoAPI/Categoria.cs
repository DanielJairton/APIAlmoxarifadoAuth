using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
    }
}
