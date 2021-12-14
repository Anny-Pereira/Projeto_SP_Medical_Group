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
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacoesController : ControllerBase
    {

        private ILocalizacaoRepository _localizacaoRepository { get; set; }

        public LocalizacoesController()
        {
            _localizacaoRepository = new LocalizacaoRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_localizacaoRepository.ListarTodas());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpPost]
        public IActionResult Cadastrar(Localizacao novaLocalizacao)
        {
            try
            {
                _localizacaoRepository.Cadastrar(novaLocalizacao);
                return Ok("O cadastro foi realizado com sucesso!");

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
