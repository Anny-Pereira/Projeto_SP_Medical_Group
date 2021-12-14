using Senai_MedicalGroup_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pela LocalizacaoRepository
    /// </summary>
    interface ILocalizacaoRepository
    {

        //Listagem
        List<Localizacao> ListarTodas();


        //Cadastro
        void Cadastrar(Localizacao novaLocalizacao);


    }
}
