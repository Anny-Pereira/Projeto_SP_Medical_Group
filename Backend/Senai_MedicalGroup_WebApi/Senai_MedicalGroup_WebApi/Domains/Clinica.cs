using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_MedicalGroup_WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório!")]
        public string NomeClinica { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public TimeSpan? HorarioAbertura { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public TimeSpan? HorarioEncerramento { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
