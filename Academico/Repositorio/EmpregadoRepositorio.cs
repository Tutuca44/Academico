using Academico.Models;
using Academico.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Academico.Repositorio
{
    public class EmpregadoRepositorio : IEmpregadoRepositorio
    {
        private readonly AcademicoContext _context;
        public EmpregadoRepositorio (AcademicoContext academicocontext)
        {
            this._context = academicocontext;
        }

        public TbEmpregado Adicionar(TbEmpregado empregado)
        {
            _context.TbEmpregados.Add(empregado);
            _context.SaveChanges();
            return empregado;
        }

        public TbEmpregado listarid(int id)
        {
            return _context.TbEmpregados.First(x => x.IdEmpregado == id);
        }

        public List<TbEmpregado> Buscartodos()
        {
            return _context.TbEmpregados.ToList();
        }

        public List<TbEmpregado> BuscarTodos(int id)
        {
            return _context.TbEmpregados.First(d => d.IdEmpregado == id).ToList();
        }

        public int ObterUltimoID()
        {
            return _context.TbEmpregados.Max(d => d.IdEmpregado);
        }

        public TbEmpregado BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public TbEmpregado Alterar(TbEmpregado empregado)
        {
            TbEmpregado empregadoDB = BuscarId(empregado.IdEmpregado);

            if (empregadoDB == null)
            {
                throw new Exception("Departamento não encontrado.");
            }

            empregadoDB.IdEmpregado = empregadoDB.IdEmpregado;
            empregadoDB.NmEmpregado = empregadoDB.NmEmpregado;
            empregadoDB.IniciaisEmpregado = empregadoDB.IniciaisEmpregado;
            empregadoDB.DsCargos = empregadoDB.DsCargos;
            //empregadoDB.IdGerente = empregadoDB.IdGerente;
            empregadoDB.DtNascimento = empregadoDB.DtNascimento;
            empregadoDB.Salario = empregadoDB.Salario;
            empregadoDB.Comissao = empregadoDB.Comissao;
            empregadoDB.IdDepartamento = empregadoDB.IdDepartamento;
            empregadoDB.FgAtivo = empregadoDB.FgAtivo;

            _context.SaveChanges();

            return empregadoDB;
        }

        public List<TbEmpregado> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public List<TbEmpregado> ToList()
        {
            throw new NotImplementedException();
        }
    }
}