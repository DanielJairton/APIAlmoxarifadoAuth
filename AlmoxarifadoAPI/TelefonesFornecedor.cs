using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class TelefonesFornecedor
    {
        public int IdTelefone { get; set; }
        public string Telefone { get; set; } = null!;
        public int IdFornecedor { get; set; }

        public virtual Fornecedore IdFornecedorNavigation { get; set; } = null!;
    }
}
