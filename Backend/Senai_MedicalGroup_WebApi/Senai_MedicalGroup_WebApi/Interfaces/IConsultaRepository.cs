using Senai_MedicalGroup_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável peloa ConsultaRepository
    /// </summary>
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todos as consultas
        /// </summary>
        /// <returns>uma lista com todos as consultas</returns>
        List<Consulta> ListarTodos();


        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta">objeto com as informações cadastradas</param>
        void Cadastrar(Consulta novaConsulta);


        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="idConsulta">id da Consulta que será deletada</param>
        void Deletar(int idConsulta);



        /// <summary>
        /// Busca uma Consulta pelo seu id
        /// </summary>
        /// <param name="idConsulta">id da Consulta que será buscada</param>
        /// <returns></returns>
        Consulta BuscarId(int idConsulta);


        /// <summary>
        /// Atualiza uma Consulta pelo seu id
        /// </summary>
        /// <param name="idConsulta">id da Consulta que será atualizada</param>
        /// <param name="consultaAtualizada">objeto Clinica com as novas informações</param>
        void Atualizar(int idConsulta, Consulta consultaAtualizada);


        /// <summary>
        /// Altera o status de uma consulta
        /// </summary>
        /// <param name="idConsulta">id da consulta que tera a situacao alterada</param>
        /// <param name="status">parametro que atualiza a sitauacao para 1-Realizada  / 2-Recusada  / 3-Agendada</param>
        void AgendarCancelar(int idConsulta, string status);


        /// <summary>
        /// Adiciona uma descricao no prontuario da consulta
        /// </summary>
        /// <param name="descricao">objeto com a descricao</param>
        void AddDescricao(int idConsulta, Consulta descricao);


        /// <summary>
        /// Lista todas as consultas de um medico
        /// </summary>
        /// <param name="idUsuario">id do medico que vera suas consultas</param>
        /// <returns>Lista de consultas de um determinado medico</returns>
        List<Consulta> ConsultasMedico(int idUsuario);



        /// <summary>
        /// Lista todas as consultas de um paciente
        /// </summary>
        /// <param name="idUsuario">id do paciente que vera suas consultas</param>
        /// <returns>Lista de consultas de um determinado paciente</returns>
        List<Consulta> ConsultasPaciente(int idUsuario);
    }
}
