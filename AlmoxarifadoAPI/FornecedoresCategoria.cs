using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class FornecedoresCategoria
    {
        public int IdFornecedor { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual Fornecedore IdFornecedorNavigation { get; set; } = null!;
    }
}
