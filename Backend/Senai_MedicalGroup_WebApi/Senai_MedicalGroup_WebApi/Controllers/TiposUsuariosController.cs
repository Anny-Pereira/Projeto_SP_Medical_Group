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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }


        public TiposUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }




        /// <summary>
        /// Lista todos os tipoUsuarios
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Busca um tipoUsuario através do seu id
        /// </summary>
        /// <param name="idTipo">id do tipoUsuario que será buscado</param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{idTipo}")]
        public IActionResult BuscarId(int idTipo)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarId(idTipo));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipo">objeto que será cadastrado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipo)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        

        /// <summary>
        /// Deleta um tipoUsuario existente
        /// </summary>
        /// <param name="idTipo">id do tipo que será deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idTipo}")]
        public IActionResult Deletar(int idTipo)
        {
            TipoUsuario tipoBuscado = _tipoUsuarioRepository.BuscarId(idTipo);

            if (tipoBuscado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Deletar(idTipo);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhum tipo de usuário foi encontrado para ser deletado!");
        }



        /// <summary>
        /// Atualiza um tipoUsuario existente
        /// </summary>
        /// <param name="idTipo">id do tipoUsuario que será atualizado</param>
        /// <param name="tipoAtualizado">objeto com as informações atualizadas</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idTipo}")]
        public IActionResult Atualizar(int idTipo, TipoUsuario tipoAtualizado)
        {
            TipoUsuario tipoBuscado = _tipoUsuarioRepository.BuscarId(idTipo);

            if (tipoBuscado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Atualizar(idTipo, tipoAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhum tipo de usuário foi encontrado para ser atualizado!");
        }

    }
}
