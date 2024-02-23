using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class EmailsFornecedor
    {
        public int IdEmail { get; set; }
        public string Email { get; set; } = null!;
        public int IdFornecedor { get; set; }

        public virtual Fornecedore IdFornecedorNavigation { get; set; } = null!;
    }
}
