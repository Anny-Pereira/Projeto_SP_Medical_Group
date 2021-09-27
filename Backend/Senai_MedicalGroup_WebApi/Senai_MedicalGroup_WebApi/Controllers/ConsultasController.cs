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
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }



        [Authorize(Roles = "2")]
        [HttpPatch("{idConsulta}")]
        public IActionResult AddDescricao(int idConsulta, Consulta ConsultaDescricao)
        {
            try
            {
                _consultaRepository.AddDescricao(idConsulta, ConsultaDescricao);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

    }
}
