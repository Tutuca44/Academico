using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Academico.Models;
using Academico.Repositorio;

namespace Academico.Controllers;

public class EmpregadoController : Controller
{
    private readonly IEmpregadoRepositorio _context;

    public EmpregadoController(IEmpregadoRepositorio empregadoRepositorio)
    {
        _context = empregadoRepositorio;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetEmpregados()
    {
        try
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sort = Request.Form["sort"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var empregados = _context.BuscarTodos();
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                empregados = (List<TbEmpregado>)empregados.OrderBy(e => e.IdDepartamento);
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                empregados = empregados.Where(e => e.NmEmpregado.Contains(searchValue)).ToList();
            }
            recordsTotal = empregados.Count();
            var data = empregados.Skip(skip).Take(pageSize).Select(e => new
            {
                idEmpregado = e.IdEmpregado,
                nmEmpregado = e.NmEmpregado,
                //dsCargo = e.DsCargo,
                dtNascimento = e.DtNascimento,
                comissao = e.Comissao,
                salario = e.Salario,
                departamento = e.TbDepartamentos.Where(d => d.IdDepartamento == e.IdDepartamento).FirstOrDefault()
            }).ToList();
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Json(jsonData);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
