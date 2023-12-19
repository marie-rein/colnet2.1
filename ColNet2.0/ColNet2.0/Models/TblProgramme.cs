using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Table("tblProgramme")]
public partial class TblProgramme
{
    [Key]
    [Column("noProgramme")]
    public int NoProgramme { get; set; }

    [Column("nomProgramme")]
    [StringLength(25)]
    [Unicode(false)]
    public string NomProgramme { get; set; } = null!;

    [InverseProperty("NoProgrammeNavigation")]
    public virtual ICollection<TblCour> TblCours { get; set; } = new List<TblCour>();

    [InverseProperty("NumProgrammeNavigation")]
    public virtual ICollection<TblEleve> TblEleves { get; set; } = new List<TblEleve>();
}
