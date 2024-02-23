using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Saida
    {
        public int IdSaida { get; set; }
        public DateTime DataSaida { get; set; }
        public string Condicao { get; set; } = null!;
        public int QuantidadeSaida { get; set; }
        public string? Nota { get; set; }
        public int IdTransacao { get; set; }
        public int IdLote { get; set; }
        public int IdFuncionarioResponsavel { get; set; }
        public int IdFuncionarioReceptor { get; set; }

        public virtual Funcionario IdFuncionarioReceptorNavigation { get; set; } = null!;
        public virtual Funcionario IdFuncionarioResponsavelNavigation { get; set; } = null!;
        public virtual Lote IdLoteNavigation { get; set; } = null!;
        public virtual Transaco IdTransacaoNavigation { get; set; } = null!;
    }
}
