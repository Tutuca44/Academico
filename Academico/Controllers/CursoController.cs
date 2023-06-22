//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Academico.Models;
//using Academico.Repositorio;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace Academico.Controllers;

//public class CursoController : Controller
//{
//    private readonly ILogger<CursoController> _logger;
//    private readonly ICursoRepositorio _cursoService;

//    public CursoController(ILogger<CursoController> logger, ICursoRepositorio _cursoService)
//    {
//        this._logger = logger;
//        this._cursoService = _cursoService;
//    }

//    public IActionResult Index()
//    {
//        return View();
//    }

//    [HttpPost]
//    public IActionResult GetCursos()
//    {
//        try
//        {
//            var draw = Request.Form["draw"].FirstOrDefault();
//            var start = Request.Form["start"].FirstOrDefault();
//            var length = Request.Form["length"].FirstOrDefault();
//            var sort = Request.Form["sort"].FirstOrDefault();
//            var searchValue = Request.Form["search[value]"].FirstOrDefault();
//            int pageSize = length != null ? Convert.ToInt32(length) : 0;
//            int skip = start != null ? Convert.ToInt32(start) : 0;
//            int recordsTotal = 0;
//            var cursos = _cursoService.GetAll();
//            if (!string.IsNullOrEmpty(searchValue))
//            {
//                cursos = cursos.Where(c => c.DsCurso.Contains(searchValue)).ToList();
//            }
//            recordsTotal = cursos.Count();
//            var data = cursos.Skip(skip).Take(pageSize).Select(c => new {
//                idCurso = c.IdCurso,
//                dsCurso = c.DsCurso,
//                categoria = c.Categoria,
//                duracao = c.Duracao,
//                ativo = c.FgAtivo
//            }).ToList();
//            var jsonData = new
//            {
//                draw = draw,
//                recordsFiltered = recordsTotal,
//                recordsTotal = recordsTotal,
//                data = data
//            };
//            return Json(jsonData);
//        }
//        catch (System.Exception)
//        {
//            throw;
//        }
//    }
//}