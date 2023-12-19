using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Models;

[Keyless]
public partial class VueHoraire
{
    [Column("nomCour")]
    [StringLength(30)]
    [Unicode(false)]
    public string NomCour { get; set; } = null!;

    [Column("session")]
    [StringLength(10)]
    [Unicode(false)]
    public string Session { get; set; } = null!;

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

    [Column("ID")]
    public int Id { get; set; }
}
