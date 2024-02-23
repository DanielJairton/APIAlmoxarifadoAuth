using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            EmailsFuncionarios = new HashSet<EmailsFuncionario>();
            Entrada = new HashSet<Entrada>();
            SaidaIdFuncionarioReceptorNavigations = new HashSet<Saida>();
            SaidaIdFuncionarioResponsavelNavigations = new HashSet<Saida>();
            TelefonesFuncionarios = new HashSet<TelefonesFuncionario>();
            Transacos = new HashSet<Transaco>();
        }

        public int IdFuncionario { get; set; }
        public string Nome { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public int IdDepartamento { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual ICollection<EmailsFuncionario> EmailsFuncionarios { get; set; }
        public virtual ICollection<Entrada> Entrada { get; set; }
        public virtual ICollection<Saida> SaidaIdFuncionarioReceptorNavigations { get; set; }
        public virtual ICollection<Saida> SaidaIdFuncionarioResponsavelNavigations { get; set; }
        public virtual ICollection<TelefonesFuncionario> TelefonesFuncionarios { get; set; }
        public virtual ICollection<Transaco> Transacos { get; set; }
    }
}
