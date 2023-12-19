using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Keyless]
public partial class VueTravailEtudiant
{
    [Column("numeroDA")]
    public int NumeroDa { get; set; }

    [Column("noTravail")]
    public int NoTravail { get; set; }

    [Column("typeTravail")]
    [StringLength(30)]
    [Unicode(false)]
    public string TypeTravail { get; set; } = null!;

    [Column("notesEleve")]
    public short? NotesEleve { get; set; }

    [Column("notesTravail")]
    public short? NotesTravail { get; set; }

    [Column("moyenneEleve")]
    public short? MoyenneEleve { get; set; }
}
