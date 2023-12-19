using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Table("tblCour")]
public partial class TblCour
{
    [Key]
    [Column("noCour")]
    public int NoCour { get; set; }

    [Column("nomCour")]
    [StringLength(30)]
    [Unicode(false)]
    public string NomCour { get; set; } = null!;

    [Column("session")]
    [StringLength(10)]
    [Unicode(false)]
    public string Session { get; set; } = null!;

    [Column("ponderation")]
    [StringLength(12)]
    [Unicode(false)]
    public string Ponderation { get; set; } = null!;

    [Column("noProgramme")]
    public int NoProgramme { get; set; }

    [ForeignKey("NoProgramme")]
    [InverseProperty("TblCours")]
    public virtual TblProgramme NoProgrammeNavigation { get; set; } = null!;

    [InverseProperty("NoCoursNavigation")]
    public virtual ICollection<TblPeriode> TblPeriodes { get; set; } = new List<TblPeriode>();

    [InverseProperty("NoCoursNavigation")]
    public virtual ICollection<TblTravaux> TblTravauxes { get; set; } = new List<TblTravaux>();

    [ForeignKey("NoCours")]
    [InverseProperty("NoCours")]
    public virtual ICollection<TblProfesseur> NoProfs { get; set; } = new List<TblProfesseur>();

    [ForeignKey("NoCours")]
    [InverseProperty("NoCours")]
    public virtual ICollection<TblEleve> NumeroDa { get; set; } = new List<TblEleve>();
}
