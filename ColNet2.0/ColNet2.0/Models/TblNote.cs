using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[PrimaryKey("NoTravail", "NumeroDa")]
[Table("tblNotes")]
public partial class TblNote
{
    

    [Key]
    [Column("noTravail")]
    public int NoTravail { get; set; }

    [Key]
    [Column("numeroDA")]
    public int NumeroDa { get; set; }

    [Column("moyenneEleve")]
    public short? MoyenneEleve { get; set; }

    [Column("notesTravail")]
    public short? NotesTravail { get; set; }

    [Column("notesEleve")]
    public short? NotesEleve { get; set; }

    [Column("commentaire")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Commentaire { get; set; }

    [ForeignKey("NoTravail")]
    [InverseProperty("TblNotes")]
    public virtual TblTravaux NoTravailNavigation { get; set; } = null!;

    [ForeignKey("NumeroDa")]
    [InverseProperty("TblNotes")]
    public virtual TblEleve NumeroDaNavigation { get; set; } = null!;
}
