using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Models;

[Table("tb_empregados")]
public partial class TbEmpregado
{
    [Key]
    [Column("id_empregado")]
    public int IdEmpregado { get; set; }

    [Column("nm_empregado")]
    [StringLength(60)]
    [Unicode(false)]
    public string NmEmpregado { get; set; } = null!;

    [Column("iniciais_empregado")]
    [StringLength(5)]
    [Unicode(false)]
    public string IniciaisEmpregado { get; set; } = null!;

    [Column("ds_cargos")]
    [StringLength(40)]
    [Unicode(false)]
    public string? DsCargos { get; set; }

    [Column("id_gerete")]
    public int? IdGerete { get; set; }

    [Column("dt_nascimento", TypeName = "date")]
    public DateTime DtNascimento { get; set; }

    [Column("salario", TypeName = "numeric(7, 2)")]
    public decimal Salario { get; set; }

    [Column("comissao")]
    public double? Comissao { get; set; }

    [Column("id_departamento")]
    public int? IdDepartamento { get; set; }

    [Column("fg_ativo")]
    public bool? FgAtivo { get; set; }

    [ForeignKey("IdGerete")]
    [InverseProperty("InverseIdGereteNavigation")]
    public virtual TbEmpregado? IdGereteNavigation { get; set; }

    [InverseProperty("IdGereteNavigation")]
    public virtual ICollection<TbEmpregado> InverseIdGereteNavigation { get; set; } = new List<TbEmpregado>();

    [InverseProperty("IdInstrutorNavigation")]
    public virtual ICollection<TbCursosOferecido> TbCursosOferecidos { get; set; } = new List<TbCursosOferecido>();

    [InverseProperty("IdGerenteNavigation")]
    public virtual ICollection<TbDepartamento> TbDepartamentos { get; set; } = new List<TbDepartamento>();

    [InverseProperty("IdEmpregadoNavigation")]
    public virtual ICollection<TbHistorico> TbHistoricos { get; set; } = new List<TbHistorico>();

    [InverseProperty("IdParticipanteNavigation")]
    public virtual ICollection<TbMatricula> TbMatriculas { get; set; } = new List<TbMatricula>();

    internal List<TbEmpregado> ToList()
    {
        throw new NotImplementedException();
    }
}
