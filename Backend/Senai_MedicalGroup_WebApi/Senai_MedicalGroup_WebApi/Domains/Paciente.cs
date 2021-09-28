using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_MedicalGroup_WebApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
