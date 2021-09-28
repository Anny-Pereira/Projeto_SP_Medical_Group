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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }


        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }



        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {

            try
            {
                return Ok(_pacienteRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Busca um pacientes através do seu id
        /// </summary>
        /// <param name="idPaciente">id do paciente que será buscado</param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{idPaciente}")]
        public IActionResult BuscarId(int idPaciente)
        {
            try
            {
                Paciente pacienteBuscado = _pacienteRepository.BuscarId(idPaciente);

                if (pacienteBuscado == null)
                {
                    return BadRequest("Nenhum paciente foi encontrado");
                }

                return Ok(_pacienteRepository.BuscarId(idPaciente));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }




        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">objeto que será cadastrado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(novoPaciente);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Deleta um paciente existente
        /// </summary>
        /// <param name="idPaciente">id do paciente que será deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idPaciente}")]
        public IActionResult Deletar(int idPaciente)
        {
            Paciente pacienteBuscado = _pacienteRepository.BuscarId(idPaciente);

            if (pacienteBuscado != null)
            {
                try
                {
                    _pacienteRepository.Deletar(idPaciente);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhum paciente foi encontrado para ser deletado!");
        }




        /// <summary>
        /// Atualiza um paciente existente
        /// </summary>
        /// <param name="idPaciente">id do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">objeto com as informações atualizadas</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idPaciente}")]
        public IActionResult Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = _pacienteRepository.BuscarId(idPaciente);

            if (pacienteBuscado != null)
            {
                try
                {
                    _pacienteRepository.Atualizar(idPaciente, pacienteAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhum paciente foi encontrado para ser atualizado!");
        }
    }
}
