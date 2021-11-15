using Microsoft.EntityFrameworkCore;
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
                consultaBuscada.Descricao = ConsultaDescricao.Descricao;

                ctx.Consulta.Update(consultaBuscada);

                ctx.SaveChanges();
            }

            else
            {
                throw new Exception("O ID informado não existe!");
            }
        }

        public void AgendarCancelar(int idConsulta, Consulta status)
        {
            Consulta consultaBuscada = ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);

            switch (status.IdSituacao)
            {
                case 1:
                    consultaBuscada.IdSituacao = 1;
                    break;

                case 2:
                    consultaBuscada.IdSituacao = 2;
                    break;


                case 3:
                    consultaBuscada.IdSituacao = 3;
                    break;


                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();

        }

        public void Atualizar(int idConsulta, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = BuscarId(idConsulta);

            if (consultaBuscada != null)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
                consultaBuscada.Descricao = consultaAtualizada.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consulta BuscarId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            if (novaConsulta.IdMedico > 0 && novaConsulta.DataConsulta > DateTime.Now)
            {
                ctx.Consulta.Add(novaConsulta);

                ctx.SaveChanges();
            }

            else
            {
                throw new Exception("Não é possível cadastrar uma consulta que não possua um médico e uma data válidos!");
            }
        }


    
        public List<Consulta> ConsultasMedico(int idUsuario)
        {
            Medico medico = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == idUsuario);

            return ctx.Consulta.Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation).Include(p => p.IdPacienteNavigation.IdUsuarioNavigation.IdClinicaNavigation).Include(c => c.IdSituacaoNavigation).Where(c => c.IdMedico == medico.IdMedico).ToList();
        }

        public List<Consulta> ConsultasPaciente(int idUsuario)
        {
            Paciente paciente = ctx.Pacientes.FirstOrDefault(p=> p.IdUsuario == idUsuario);

            return ctx.Consulta.Include(c => c.IdPacienteNavigation).Include(p => p.IdMedicoNavigation.IdUsuarioNavigation.IdClinicaNavigation).Include(c => c.IdSituacaoNavigation).Where(c => c.IdPaciente == paciente.IdPaciente).ToList();
        }

        public void Deletar(int idConsulta)
        {
            Consulta consultaBuscada = BuscarId(idConsulta);

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> ListarTodos()
        {
            return ctx.Consulta.Include(c  => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).Include(p => p.IdPacienteNavigation.IdUsuarioNavigation.IdClinicaNavigation).Include(c => c.IdSituacaoNavigation).ToList();
        }
    }
}
