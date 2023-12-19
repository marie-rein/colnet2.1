using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Table("tblLogin")]
public partial class TblLogin
{
    [Key]
    [Column("idLogin")]
    public int IdLogin { get; set; }

    [Column("password")]
    [MaxLength(64)]
    public byte[] Password { get; set; } = null!;

    [Column("sel")]
    public Guid? Sel { get; set; }

    [InverseProperty("IdLoginNavigation")]
    public virtual ICollection<TblAdmin> TblAdmins { get; set; } = new List<TblAdmin>();

    [InverseProperty("IdLoginNavigation")]
    public virtual ICollection<TblEleve> TblEleves { get; set; } = new List<TblEleve>();

    [InverseProperty("IdLoginNavigation")]
    public virtual ICollection<TblProfesseur> TblProfesseurs { get; set; } = new List<TblProfesseur>();
}
