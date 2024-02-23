using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class TelefonesFuncionario
    {
        public int IdTelefone { get; set; }
        public string Telefone { get; set; } = null!;
        public int IdFuncionario { get; set; }

        public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;
    }
}
