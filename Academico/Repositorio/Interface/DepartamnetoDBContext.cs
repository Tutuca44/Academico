﻿//using Academico.Models;
//using System.Collections.Generic;
//verride DbSet<TbDepartamentos> Set => (_context as AcademicoContext)!.TbDepartamentos;

//protected override List<string> GetIncludeRelationship()
//{
//    return new() { "IdGerenteNavigation", "TbHistoricos" };
//}

//public DepartamentoDBContext(AcademicoContext context) : base(context)
//    {
//}

//public int GetNextId()
//{
//    return Set.OrderBy(m => m.IdDepartamento).Reverse().FirstOrDefault()!.IdDepartamento + 10;
//}

//public override void Create(TbDepartamentos entity)
//{
//    entity.FgAtivo = true;
//    base.Create(entity);
//}

//public TbDepartamentos Get(TbDepartamentos entity)
//{
//    return base.Get(e => e.IdDepartamento == entity.IdDepartamento);
//}
//}