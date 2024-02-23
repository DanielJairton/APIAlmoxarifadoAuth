using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Entrada
    {
        public Entrada()
        {
            Lotes = new HashSet<Lote>();
        }

        public int IdEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Condicao { get; set; } = null!;
        public string? Nota { get; set; }
        public int IdTransacao { get; set; }
        public int IdFuncionario { get; set; }

        public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;
        public virtual Transaco IdTransacaoNavigation { get; set; } = null!;
        public virtual ICollection<Lote> Lotes { get; set; }
    }
}
