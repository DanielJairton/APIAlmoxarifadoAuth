using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Lote
    {
        public Lote()
        {
            Saida = new HashSet<Saida>();
        }

        public int IdLote { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeEntrada { get; set; }
        public int QuantidadeAtual { get; set; }
        public DateTime? DataValidade { get; set; }
        public string Localizacao { get; set; } = null!;
        public int IdEntrada { get; set; }
        public int IdItem { get; set; }
        public int IdFornecedor { get; set; }

        public virtual Entrada IdEntradaNavigation { get; set; } = null!;
        public virtual Fornecedore IdFornecedorNavigation { get; set; } = null!;
        public virtual Iten IdItemNavigation { get; set; } = null!;
        public virtual ICollection<Saida> Saida { get; set; }
    }
}
