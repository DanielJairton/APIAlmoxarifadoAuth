using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Departamento
    {
        public Departamento()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public int IdDepartamento { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
