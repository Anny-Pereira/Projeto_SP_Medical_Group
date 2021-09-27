using Senai_MedicalGroup_WebApi.Contexts;
using Senai_MedicalGroup_WebApi.Domains;
using Senai_MedicalGroup_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        MedGroupContext ctx = new MedGroupContext();
        
        public void AddDescricao(int idConsulta, Consulta ConsultaDescricao)
        {
            Consulta consultaBuscada = BuscarId(idConsulta);

            if (consultaBuscada != null)
            {
                if (consultaBuscada.Descricao != null)
                {
                    consultaBuscada.Descricao = ConsultaDescricao.Descricao;

                    ctx.Consulta.Update(consultaBuscada);

                    ctx.SaveChanges();
                }
               
            }

        }

        public void AgendarCancelar(int idConsulta, string status)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int idConsulta, Consulta consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consulta BuscarId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ConsultasMedico(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ConsultasPaciente(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idConsulta)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
