using Senai_MedicalGroup_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo MedicoRepository
    /// </summary>
    interface IMedicoRepository
    {

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns></returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">objeto com as informações cadastradas</param>
        void Cadastrar(Medico novoMedico);


        /// <summary>
        /// Deleta um medico existente
        /// </summary>
        /// <param name="idMedico">id do medico que será deletado</param>
        void Deletar(int idMedico);



        /// <summary>
        /// Busca um medico pelo seu id
        /// </summary>
        /// <param name="idMedico">id do medico que será buscado</param>
        /// <returns></returns>
        Medico BuscarId(int idMedico);


        /// <summary>
        /// Atualiza um medico pelo seu id
        /// </summary>
        /// <param name="idMedico">id do medico que será atualizado</param>
        /// <param name="medicoAtualizado">objeto Medico com as novas informações</param>
        void Atualizar(int idMedico, Medico medicoAtualizado);

    }
}
