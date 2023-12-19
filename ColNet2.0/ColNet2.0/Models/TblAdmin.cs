using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Table("tblAdmin")]
[Index("CourrielAdmin", Name = "uc_courrielAdmin", IsUnique = true)]
[Index("NumTelAdmin", Name = "uc_numeroTelAdmin", IsUnique = true)]
public partial class TblAdmin
{
    [Key]
    [Column("noAdmin")]
    public int NoAdmin { get; set; }

    [Column("nomAdmin")]
    [StringLength(50)]
    [Unicode(false)]
    public string NomAdmin { get; set; } = null!;

    [Column("prenAdmin")]
    [StringLength(50)]
    [Unicode(false)]
    public string PrenAdmin { get; set; } = null!;

    [Column("courrielAdmin")]
    [StringLength(65)]
    [Unicode(false)]
    public string CourrielAdmin { get; set; } = null!;

    [Column("numTelAdmin")]
    [StringLength(20)]
    [Unicode(false)]
    public string NumTelAdmin { get; set; } = null!;

    [Column("villeAdmin")]
    [StringLength(30)]
    [Unicode(false)]
    public string VilleAdmin { get; set; } = null!;

    [Column("noRueAdmin")]
    public short NoRueAdmin { get; set; }

    [Column("nomRueAdmin")]
    [StringLength(30)]
    [Unicode(false)]
    public string NomRueAdmin { get; set; } = null!;

    [Column("pays")]
    [StringLength(90)]
    [Unicode(false)]
    public string Pays { get; set; } = null!;

    [Column("idLogin")]
    public int IdLogin { get; set; }

    [ForeignKey("IdLogin")]
    [InverseProperty("TblAdmins")]
    public virtual TblLogin IdLoginNavigation { get; set; } = null!;
}
