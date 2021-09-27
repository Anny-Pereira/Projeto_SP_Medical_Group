using Microsoft.AspNetCore.Http;
using Senai_MedicalGroup_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>uma lista com todos os Usuarios</returns>
        List<Usuario> ListarTodos();


        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">objeto com as informações cadastradas</param>
        void Cadastrar(Usuario novoUsuario);


        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idUsuario">id do usuario que será deletado</param>
        void Deletar(int idUsuario);



        /// <summary>
        /// Busca um usuario pelo seu id
        /// </summary>
        /// <param name="idUsuario">id do usuario que será buscado</param>
        /// <returns></returns>
        Usuario BuscarId(int idUsuario);


        /// <summary>
        /// Atualiza um usuario pelo seu id
        /// </summary>
        /// <param name="idUsuario">id do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">objeto Usuario com as novas informações</param>
        void Atualizar(int idUsuario, Usuario usuarioAtualizado);



        /// <summary>
        /// Valida um usuario
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>Objeto Usuario que foi encontrado</returns>
        Usuario Login(string email, string senha);


        /// <summary>
        /// Realiza upload de uma imagem no diretorio
        /// </summary>
        /// <param name="foto"></param>
        /// <param name="id_usuario"></param>
        string SalvarPerfilDir(IFormFile foto, int id_usuario);


        /// <summary>
        /// Consulta uma imagem
        /// </summary>
        /// <param name="id_usuario">id do usuario que possui a imagem</param>
        string ConsultarPerfilDir(int id_usuario);
    }
}
