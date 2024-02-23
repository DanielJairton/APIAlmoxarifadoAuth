using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Fornecedore
    {
        public Fornecedore()
        {
            EmailsFornecedors = new HashSet<EmailsFornecedor>();
            EnderecosFornecedors = new HashSet<EnderecosFornecedor>();
            Lotes = new HashSet<Lote>();
            TelefonesFornecedors = new HashSet<TelefonesFornecedor>();
        }

        public int IdFornecedor { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }

        public virtual ICollection<EmailsFornecedor> EmailsFornecedors { get; set; }
        public virtual ICollection<EnderecosFornecedor> EnderecosFornecedors { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
        public virtual ICollection<TelefonesFornecedor> TelefonesFornecedors { get; set; }
    }
}
