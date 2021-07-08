using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoU { get; set; }
        public string TituloUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
