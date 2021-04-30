using System;
using System.Collections.Generic;

#nullable disable

namespace hroads_tarde_webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public string CapacidadeMaxvida { get; set; }
        public string CapacidadeMaxmana { get; set; }
        public string DataAtualizacao { get; set; }
        public string DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
