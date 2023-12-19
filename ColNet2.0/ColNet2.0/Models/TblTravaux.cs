using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Table("tblTravaux")]
public partial class TblTravaux
{
    [Key]
    [Column("noTravail")]
    public int NoTravail { get; set; }

    [Column("noCours")]
    public int NoCours { get; set; }

    [Column("titre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Titre { get; set; } = null!;

    [Column("typeTravail")]
    [StringLength(30)]
    [Unicode(false)]
    public string TypeTravail { get; set; } = null!;

    [Column("instruction")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Instruction { get; set; }

    [Column("dateAffectation", TypeName = "date")]
    public DateTime DateAffectation { get; set; }

    [Column("echeance", TypeName = "date")]
    public DateTime Echeance { get; set; }

    [ForeignKey("NoCours")]
    [InverseProperty("TblTravauxes")]
    public virtual TblCour NoCoursNavigation { get; set; } = null!;

    [InverseProperty("NoTravailNavigation")]
    public virtual ICollection<TblNote> TblNotes { get; set; } = new List<TblNote>();
}
