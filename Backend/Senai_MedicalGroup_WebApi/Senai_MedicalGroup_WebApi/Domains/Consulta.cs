using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_MedicalGroup_WebApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }


        [Required(ErrorMessage ="É necessário informar o médico da consulta!")]
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }


        [Required(ErrorMessage = "É necessário informar a data da consulta!")]
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
