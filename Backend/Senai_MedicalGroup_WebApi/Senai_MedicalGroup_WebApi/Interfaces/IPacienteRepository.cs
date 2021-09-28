using Senai_MedicalGroup_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo PacienteRepository
    /// </summary>
    interface IPacienteRepository
    {

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns></returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="novoPaciente">objeto com as informações cadastradas</param>
        void Cadastrar(Paciente novoPaciente);


        /// <summary>
        /// Deleta um Paciente existente
        /// </summary>
        /// <param name="idPaciente">id do Paciente que será deletado</param>
        void Deletar(int idPaciente);



        /// <summary>
        /// Busca um Paciente pelo seu id
        /// </summary>
        /// <param name="idPaciente">id do Paciente que será buscado</param>
        /// <returns></returns>
        Paciente BuscarId(int idPaciente);


        /// <summary>
        /// Atualiza um Paciente pelo seu id
        /// </summary>
        /// <param name="idPaciente">id do Paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">objeto Paciente com as novas informações</param>
        void Atualizar(int idPaciente, Paciente pacienteAtualizado);

    }
}
