using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class EnderecosFornecedor
    {
        public int IdEndereco { get; set; }
        public string Logadouro { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public int IdFornecedor { get; set; }

        public virtual Fornecedore IdFornecedorNavigation { get; set; } = null!;
    }
}
