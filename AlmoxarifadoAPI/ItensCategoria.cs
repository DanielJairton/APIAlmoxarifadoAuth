using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class ItensCategoria
    {
        public int IdItem { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual Iten IdItemNavigation { get; set; } = null!;
    }
}
