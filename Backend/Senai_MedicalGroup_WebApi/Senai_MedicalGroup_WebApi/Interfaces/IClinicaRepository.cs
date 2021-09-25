using Senai_MedicalGroup_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Interfaces
{
    /// <summary>
    /// Interface resonsável pela ClinicaRepository
    /// </summary>
    interface IClinicaRepository
    {

        /// <summary>
        /// Lista todos as clinicas
        /// </summary>
        /// <returns>uma lista com todos as clinicas</returns>
        List<Clinica> ListarTodos();


        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">objeto com as informações cadastradas</param>
        void Cadastrar(Clinica novaClinica);


        /// <summary>
        /// Deleta uma clinica existente
        /// </summary>
        /// <param name="idClinica">id da Clinica que será deletada</param>
        void Deletar(int idClinica);



        /// <summary>
        /// Busca uma clinica pelo seu id
        /// </summary>
        /// <param name="idClinica">id da clinica que será buscada</param>
        /// <returns></returns>
        Clinica BuscarId(int idClinica);


        /// <summary>
        /// Atualiza uma clinica pelo seu id
        /// </summary>
        /// <param name="idClinica">id da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">objeto Clinica com as novas informações</param>
        void Atualizar(int idClinica, Clinica clinicaAtualizada);

    }
}
