using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ColNet2._0.CustomModels;

namespace ColNet2._0.Models;

[Table("tblEleve")]
[Index("CourrielEleve", Name = "uc_courrielEleve", IsUnique = true)]
[Index("TelEleve", Name = "uc_numeroTel", IsUnique = true)]
public partial class TblEleve
{
    [Key]
    [Column("numeroDA")]
    public int NumeroDa { get; set; }

    [Column("nomEleve")]
    [StringLength(25)]
    [Unicode(false)]
    public string NomEleve { get; set; } = null!;

    [Column("prenEleve")]
    [StringLength(25)]
    [Unicode(false)]
    public string PrenEleve { get; set; } = null!;

    [Column("courrielEleve")]
    [StringLength(40)]
    [Unicode(false)]
    [EmailDomainValidator(AllowedDomain ="etu.cegepjonquiere.ca")]
    [Required(ErrorMessage ="Le courriel est obligatoire")]
    public string CourrielEleve { get; set; } = null!;

    [Column("telEleve")]
    [StringLength(20)]
    [Unicode(false)]
    public string TelEleve { get; set; } = null!;

    [Column("villeEleve")]
    [StringLength(30)]
    [Unicode(false)]
    public string VilleEleve { get; set; } = null!;

    [Column("noRueEleve")]
    public short NoRueEleve { get; set; }

    [Column("nomRueEleve")]
    [StringLength(30)]
    [Unicode(false)]
    public string NomRueEleve { get; set; } = null!;

    [Column("pays")]
    [StringLength(90)]
    [Unicode(false)]
    public string Pays { get; set; } = null!;

    [Column("numProgramme")]
    public int NumProgramme { get; set; }

    [Column("idLogin")]
    public int IdLogin { get; set; }

    [ForeignKey("IdLogin")]
    [InverseProperty("TblEleves")]
    public virtual TblLogin IdLoginNavigation { get; set; } = null!;

    [ForeignKey("NumProgramme")]
    [InverseProperty("TblEleves")]
    public virtual TblProgramme NumProgrammeNavigation { get; set; } = null!;

    [InverseProperty("NumeroDaNavigation")]
    public virtual ICollection<TblNote> TblNotes { get; set; } = new List<TblNote>();

    [ForeignKey("NumeroDa")]
    [InverseProperty("NumeroDa")]
    public virtual ICollection<TblCour> NoCours { get; set; } = new List<TblCour>();
}
