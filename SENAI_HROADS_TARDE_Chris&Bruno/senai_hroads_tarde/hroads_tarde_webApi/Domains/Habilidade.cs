using System;
using System.Collections.Generic;

#nullable disable

namespace hroads_tarde_webApi.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public int? IdTipo { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoNavigation { get; set; }
    }
}
