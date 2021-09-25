using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_MedicalGroup_WebApi.Domains
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public int? IdUsuario { get; set; }

        public string NomeAdministrador { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
