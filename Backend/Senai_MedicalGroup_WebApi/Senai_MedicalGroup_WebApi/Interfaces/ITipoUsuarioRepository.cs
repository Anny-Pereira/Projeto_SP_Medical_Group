using Senai_MedicalGroup_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tiposUsuario
        /// </summary>
        /// <returns>uma lista com todos os TipoUsuario</returns>
        List<TipoUsuario> ListarTodos();


        /// <summary>
        /// Cadastra um novo tipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">objeto com as informações cadastradas</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);


        /// <summary>
        /// Deleta um tipoUsuario existente
        /// </summary>
        /// <param name="idTipoUsuario">id do tipoUsuario que será deletado</param>
        void Deletar(int idTipoUsuario);



        /// <summary>
        /// Busca um tipoUsuario pelo seu id
        /// </summary>
        /// <param name="idTipoUsuario">id do tipoUsuario que será buscado</param>
        /// <returns></returns>
        TipoUsuario BuscarId(int idTipoUsuario);


        /// <summary>
        /// Atualiza um tipoUsuario pelo seu id
        /// </summary>
        /// <param name="idTipoUsuario">id do TipoUsuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">objeto TipoUsuario com as novas informações</param>
        void Atualizar(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado);




    }
}
