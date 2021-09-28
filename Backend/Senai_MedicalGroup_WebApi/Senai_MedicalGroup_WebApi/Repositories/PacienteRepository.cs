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
    public class PacienteRepository : IPacienteRepository
    {
        MedGroupContext ctx = new MedGroupContext();

        public void Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = BuscarId(idPaciente);

            if (pacienteBuscado != null)
            {
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
                pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
                pacienteBuscado.Endereco = pacienteAtualizado.Endereco;
            }

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(p=> p.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            Paciente pacienteBuscado = BuscarId(idPaciente);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.Include(p=> p.IdUsuarioNavigation).ToList();
        }
    }
}
