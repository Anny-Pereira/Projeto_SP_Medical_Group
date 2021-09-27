using Senai_MedicalGroup_WebApi.Contexts;
using Senai_MedicalGroup_WebApi.Domains;
using Senai_MedicalGroup_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        MedGroupContext ctx = new MedGroupContext();

        public void Atualizar(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoBuscado = BuscarId(idTipoUsuario);

            if (tipoBuscado != null)
            {
                tipoBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarId(int idTipoUsuario)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t=> t.IdTipoUsuario == idTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            TipoUsuario tipoBuscado = BuscarId(idTipoUsuario);

            ctx.TipoUsuarios.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
