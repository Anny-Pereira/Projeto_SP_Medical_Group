using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_MedicalGroup_WebApi.Domains;
using Senai_MedicalGroup_WebApi.Interfaces;
using Senai_MedicalGroup_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        //ListarTodos
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns></returns>
        ///
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns>retorna o usuario cadastrado e um statusCode</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarId(idUsuario);

            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Deletar(idUsuario);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhum usuário foi encontrado para ser delatado!");
        }



        /// <summary>
        /// Busca um usuario através do seu id
        /// </summary>
        /// <param name="idUsuario">id do usuario que será buscado</param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarId(int idUsuario)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarId(idUsuario));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Atualiza os dados de um usuario existente
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="usuarioAtualizado"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarId(idUsuario);

            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhum usuário foi encontrado para ser atualizado!");
        }
    }
}
