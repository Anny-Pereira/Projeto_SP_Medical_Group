using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_MedicalGroup_WebApi.Domains;
using Senai_MedicalGroup_WebApi.Interfaces;
using Senai_MedicalGroup_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }



        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles ="1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_consultaRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">objeto com as informações cadastradas</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// deleta uma consulta existente
        /// </summary>
        /// <param name="idConsulta">id da consulta que será deletada</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idConsulta}")]
        public IActionResult Deletar(int idConsulta)
        {

            Consulta consultaBuscada = _consultaRepository.BuscarId(idConsulta);

            if (consultaBuscada != null)
            {
                try
                {
                    _consultaRepository.Deletar(idConsulta);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhuma consulta foi encontrada para ser deletada!");
        }


        /// <summary>
        /// Atualiza uma consulta atraves do seu id
        /// </summary>
        /// <param name="idConsulta">id da consulta que sera atualizada</param>
        /// <param name="consultaAtualizada">objeto com as novas informações</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idConsulta}")]
        public IActionResult Atualizar(int idConsulta, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = _consultaRepository.BuscarId(idConsulta);

            if (consultaBuscada != null)
            {
                try
                {
                    _consultaRepository.Atualizar(idConsulta, consultaAtualizada);

                    return NoContent();
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhuma consulta foi encontrada para ser atualizada!");
        }



        /// <summary>
        /// Busca uma consulta pelo seu id
        /// </summary>
        /// <param name="idConsulta">id da consulta que será buscada</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idConsulta}")]
        public IActionResult BuscarId(int idConsulta)
        {
            try
            {
                return Ok(_consultaRepository.BuscarId(idConsulta));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// adiciona descricao na consulta
        /// </summary>
        /// <param name="idConsulta">id da consulta que terá a descricao alterada</param>
        /// <param name="ConsultaDescricao">objeto com a nova informação</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPatch("descricao/{idConsulta}")]
        public IActionResult AddDescricao(int idConsulta, Consulta ConsultaDescricao)
        {
            try
            {
                if (ConsultaDescricao.Descricao == null)
                {
                    return BadRequest("É necessário informar a descrição!");
                }

                _consultaRepository.AddDescricao(idConsulta, ConsultaDescricao);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }




        /// <summary>
        /// Define o status de uma determinada consulta para 1-Realizada / 2-Cancelada / 3-Agendada
        /// </summary>
        /// <param name="idConsulta">id da consulta que será modificado</param>
        /// <param name="status">status enviado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{idConsulta}")]
        public IActionResult AgendarCancelar(int idConsulta, Consulta status)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarId(idConsulta);

                if (consultaBuscada == null)
                {
                    return BadRequest("Algo deu errado! Talvez essa consulta não exista.");
                }

                _consultaRepository.AgendarCancelar(idConsulta, status);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }





        /// <summary>
        /// Lista as consultas de um determinado médico
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet("medico")]
        public IActionResult ConsultasMedico()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c=> c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ConsultasMedico(idUsuario)); 

            }
            catch (Exception erro)
            {

                return BadRequest(new { mensagem= "Não é possível exibir as consultas se o usuário não estiver logado!", erro});
            }
        }



        /// <summary>
        /// Lista as consultas de um determinado paciente
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "3")]
        [HttpGet("paciente")]
        public IActionResult ConsultasPaciente()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ConsultasPaciente(idUsuario));
            }
            catch (Exception erro)
            {

                return BadRequest(new { mensagem = "Não é possível exibir as consultas se o usuário não estiver logado!", erro });
            }
        }


    }
}
