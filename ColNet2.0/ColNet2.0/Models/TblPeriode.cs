using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Table("tblPeriode")]
public partial class TblPeriode
{
    [Key]
    [Column("noPeriode")]
    public int NoPeriode { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string HeureDebut { get; set; } = null!;

    [Column("heureFin")]
    [StringLength(10)]
    [Unicode(false)]
    public string HeureFin { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string Jours { get; set; } = null!;

    [Column("locale")]
    [StringLength(8)]
    [Unicode(false)]
    public string Locale { get; set; } = null!;

    [Column("noCours")]
    public int NoCours { get; set; }

    [ForeignKey("NoCours")]
    [InverseProperty("TblPeriodes")]
    public virtual TblCour NoCoursNavigation { get; set; } = null!;
}
