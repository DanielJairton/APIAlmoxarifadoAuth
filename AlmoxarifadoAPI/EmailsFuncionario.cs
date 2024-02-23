using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class EmailsFuncionario
    {
        public int IdEmail { get; set; }
        public string Email { get; set; } = null!;
        public int IdFuncionario { get; set; }

        public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;
    }
}
