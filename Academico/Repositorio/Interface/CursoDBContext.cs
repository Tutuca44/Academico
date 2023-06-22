//using Aperfeicoa.Models;
//using Aperfeicoa.Data;
//using Aperfeicoa.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Academico.Models;

//namespace Aperfeicoa.Services;

//public class CursoDBContext : AperfeicoaDBContext<TbCursos>, ICursoService
//{
//    protected override DbSet<TbCursos> Set => (_context as AcademicoContext)!.TbCursos;

//    protected override List<string> GetIncludeRelationship()
//    {
//        return new() { "TbCursosOferecidos" };
//    }

//    public TbCursos Get(TbCursos entity)
//    {
//        return base.Get(e => e.IdCurso == entity.IdCurso);
//    }

//    public CursoDBContext(AcademicoContext context) : base(context)
//    {

//    }


//}