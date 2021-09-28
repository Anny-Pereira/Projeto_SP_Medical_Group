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
    public class MedicoRepository : IMedicoRepository
    {
        MedGroupContext ctx = new MedGroupContext();

        public void Atualizar(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = BuscarId(idMedico);

            if (medicoBuscado != null)
            {
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
                medicoBuscado.Crm = medicoAtualizado.Crm;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarId(int idMedico)
        {

            return ctx.Medicos.FirstOrDefault(m=> m.IdMedico == idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            Medico medicoBuscado = BuscarId(idMedico);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.Include(m=> m.IdEspecialidadeNavigation).ToList();
        }
    }
}
