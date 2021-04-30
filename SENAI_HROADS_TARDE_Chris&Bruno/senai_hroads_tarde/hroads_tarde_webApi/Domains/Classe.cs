using System;
using System.Collections.Generic;

#nullable disable

namespace hroads_tarde_webApi.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagens = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        public string NomeClasse { get; set; }

        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
