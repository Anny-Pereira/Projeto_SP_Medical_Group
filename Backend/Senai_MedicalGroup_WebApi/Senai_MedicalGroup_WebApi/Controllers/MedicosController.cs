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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository {get; set;}


        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }




        /// <summary>
        /// Lista todos os médicos
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {

            try
            {
                return Ok(_medicoRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Busca um medico através do seu id
        /// </summary>
        /// <param name="idMedico">id do medico que será buscado</param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{idMedico}")]
        public IActionResult BuscarId(int idMedico)
        {
            try
            {
                Medico medicoBuscado = _medicoRepository.BuscarId(idMedico);

                if (medicoBuscado == null)
                {
                    return BadRequest("Nenhum médico foi encontrado");
                }

                return Ok(_medicoRepository.BuscarId(idMedico));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }




        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">objeto que será cadastrado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            try
            {
                _medicoRepository.Cadastrar(novoMedico);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Deleta um medico existente
        /// </summary>
        /// <param name="idMedico">id do medico que será deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            Medico medicoBuscado = _medicoRepository.BuscarId(idMedico);

            if (medicoBuscado != null)
            {
                try
                {
                    _medicoRepository.Deletar(idMedico);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhum médico foi encontrado para ser deletado!");
        }




        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="idMedico">id do medico que será atualizado</param>
        /// <param name="medicoAtualizado">objeto com as informações atualizadas</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idMedico}")]
        public IActionResult Atualizar(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = _medicoRepository.BuscarId(idMedico);

            if (medicoBuscado != null)
            {
                try
                {
                    _medicoRepository.Atualizar(idMedico, medicoAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return BadRequest("Nenhum médico foi encontrado para ser atualizado!");
        }

    }
}
