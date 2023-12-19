using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Table("tblProfesseur")]
[Index("CourrielProf", Name = "uc_courrielProf", IsUnique = true)]
[Index("TelProf", Name = "uc_numeroTelProf", IsUnique = true)]
public partial class TblProfesseur
{
    [Key]
    [Column("noProf")]
    public int NoProf { get; set; }

    [Column("nomProf")]
    [StringLength(25)]
    [Unicode(false)]
    public string NomProf { get; set; } = null!;

    [Column("prenProf")]
    [StringLength(25)]
    [Unicode(false)]
    public string PrenProf { get; set; } = null!;

    [Column("courrielProf")]
    [StringLength(40)]
    [Unicode(false)]
    public string CourrielProf { get; set; } = null!;

    [Column("telProf")]
    [StringLength(20)]
    [Unicode(false)]
    public string TelProf { get; set; } = null!;

    [Column("villeProf")]
    [StringLength(30)]
    [Unicode(false)]
    public string VilleProf { get; set; } = null!;

    [Column("noRueProf")]
    public short NoRueProf { get; set; }

    [Column("nomRueProf")]
    [StringLength(30)]
    [Unicode(false)]
    public string NomRueProf { get; set; } = null!;

    [Column("pays")]
    [StringLength(90)]
    [Unicode(false)]
    public string Pays { get; set; } = null!;

    [Column("idLogin")]
    public int IdLogin { get; set; }

    [ForeignKey("IdLogin")]
    [InverseProperty("TblProfesseurs")]
    public virtual TblLogin IdLoginNavigation { get; set; } = null!;

    [ForeignKey("NoProf")]
    [InverseProperty("NoProfs")]
    public virtual ICollection<TblCour> NoCours { get; set; } = new List<TblCour>();
}
