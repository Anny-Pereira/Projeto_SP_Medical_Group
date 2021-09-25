using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.ViewModels
{
    /// <summary>
    /// Classe responsável pelo modelo de login
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "É necessário informar o e-mail do usuário!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "É necessário informar a senha do usuário!")]
        public string Senha { get; set; }

    }
}
