using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Transaco
    {
        public Transaco()
        {
            Entrada = new HashSet<Entrada>();
            Saida = new HashSet<Saida>();
        }

        public int IdTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public string Tipo { get; set; } = null!;
        public string Motivo { get; set; } = null!;
        public int IdFuncionario { get; set; }

        public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;
        public virtual ICollection<Entrada> Entrada { get; set; }
        public virtual ICollection<Saida> Saida { get; set; }
    }
}
