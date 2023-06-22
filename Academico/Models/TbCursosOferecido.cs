﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Models;

[PrimaryKey("IdCurso", "DtInicio")]
[Table("tb_cursos_oferecidos")]
public partial class TbCursosOferecido
{
    [Key]
    [Column("id_curso")]
    [StringLength(6)]
    [Unicode(false)]
    public string IdCurso { get; set; } = null!;

    [Key]
    [Column("dt_inicio", TypeName = "date")]
    public DateTime DtInicio { get; set; }

    [Column("id_instrutor")]
    public int? IdInstrutor { get; set; }

    [Column("localizacao")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Localizacao { get; set; }

    [Column("fg_ativo")]
    public bool? FgAtivo { get; set; }

    [ForeignKey("IdCurso")]
    [InverseProperty("TbCursosOferecidos")]
    public virtual TbCurso IdCursoNavigation { get; set; } = null!;

    [ForeignKey("IdInstrutor")]
    [InverseProperty("TbCursosOferecidos")]
    public virtual TbEmpregado? IdInstrutorNavigation { get; set; }

    [InverseProperty("TbCursosOferecido")]
    public virtual ICollection<TbMatricula> TbMatriculas { get; set; } = new List<TbMatricula>();
}
