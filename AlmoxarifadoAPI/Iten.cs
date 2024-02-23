using System;
using System.Collections.Generic;

namespace AlmoxarifadoAPI
{
    public partial class Iten
    {
        public Iten()
        {
            Lotes = new HashSet<Lote>();
        }

        public int IdItem { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }

        public virtual ICollection<Lote> Lotes { get; set; }
    }
}
