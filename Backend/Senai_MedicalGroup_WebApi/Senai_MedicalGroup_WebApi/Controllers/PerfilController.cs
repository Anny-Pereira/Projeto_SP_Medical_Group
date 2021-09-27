using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_MedicalGroup_WebApi.Interfaces;
using Senai_MedicalGroup_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public PerfilController()
        {
            _usuarioRepository = new UsuarioRepository();
        }



        /// <summary>
        /// Salva uma foto no diretorio
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        [Authorize(Roles = "1,2,3")]
        [HttpPost("imagem")]
        public IActionResult PostarDir(IFormFile arquivo)
        {
            try
            {
                //Analisa se tamanho do arquivo é maior que 5MB
                if (arquivo.Length > 5000000) 
                {
                    return BadRequest(new {mensagem = "O tamanho máximo da imagem é de 5MB!" });
                }

                string extensao = arquivo.FileName.Split('.').Last();
                if (extensao != "png" && extensao != "jpg")
                {
                    return BadRequest(new {mensagem = "Apenas arquivos .png ou .jpg são permitidos!" });
                }

                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(u=> u.Type == JwtRegisteredClaimNames.Jti).Value);

                string resposta = _usuarioRepository.SalvarPerfilDir(arquivo, IdUsuario);

                if (resposta == null)
                {
                    return BadRequest("Não foi possível salvar a imagem!");
                }

   

                return Ok();

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }




        /// <summary>
        /// Consulta uma imagem no diretório
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1,2,3")]
        [HttpGet("imagem")]
        public IActionResult ConsultarDir()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value);

                string Base64 = _usuarioRepository.ConsultarPerfilDir(IdUsuario);

                return Ok(Base64);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
