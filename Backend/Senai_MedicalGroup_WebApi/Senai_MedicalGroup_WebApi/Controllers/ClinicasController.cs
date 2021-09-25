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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository {get; set;}

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }



        //ListarTodos
        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Retorna uma lista de clinicas</returns>
        /// 
        [Authorize(Roles= "1")]
        [HttpGet]
        public IActionResult ListarToods()
        {
            try
            {
                return Ok(_clinicaRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        //Cadastrar
        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">Objeto Clinica com as informaçoes</param>
        /// <returns>Retorna um StatusCode</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPost]
       public IActionResult Cadastrar(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        //Deletar
        /// <summary>
        /// Deleta uma clinica existente
        /// </summary>
        /// <param name="idClinica">id da clinica que será deletada</param>
        /// <returns>StatusCode</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{idClinica}")]
        public IActionResult Deletar(int idClinica)
        {
            Clinica clinicaBuscada = _clinicaRepository.BuscarId(idClinica);

            if (clinicaBuscada != null)
            {

                try
                {
                    _clinicaRepository.Deletar(idClinica);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return NotFound("Nenhuma clínica foi encontrada para ser deletada!");
        }



        //BuscarId
        /// <summary>
        /// Busca uma clinica pelo seu id
        /// </summary>
        /// <param name="idClinica">id da clinica que será buscada</param>
        /// <returns>objeto clinica e um StatusCode</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{idClinica}")]
        public IActionResult BuscarId(int idClinica)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarId(idClinica));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        //Atualizar
        /// <summary>
        /// Atualiza uma clinica existene
        /// </summary>
        /// <param name="idClinica">is da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">objeto Clinica com as novas informações</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idClinica}")]
        public IActionResult Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = _clinicaRepository.BuscarId(idClinica);

            if (clinicaBuscada != null)
            {
                try
                {
                    _clinicaRepository.Atualizar(idClinica, clinicaAtualizada);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound("Nenhuma clínica foi encontrada para ser atualizada!");
        }


    }
}
