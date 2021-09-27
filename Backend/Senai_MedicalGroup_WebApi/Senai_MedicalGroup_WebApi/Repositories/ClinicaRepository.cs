using Senai_MedicalGroup_WebApi.Contexts;
using Senai_MedicalGroup_WebApi.Domains;
using Senai_MedicalGroup_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        MedGroupContext ctx = new MedGroupContext();

        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicBuscada = BuscarId(idClinica);


            if (clinicaAtualizada != null)
            {
                clinicBuscada.NomeClinica = clinicaAtualizada.NomeClinica;
                clinicBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
                clinicBuscada.Cnpj = clinicaAtualizada.Cnpj;
                clinicBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
                clinicBuscada.HorarioEncerramento = clinicaAtualizada.HorarioEncerramento;
            }

            ctx.Clinicas.Update(clinicBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == idClinica);

        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica clinicaBuscada = BuscarId(idClinica);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();

        }
    }
}
