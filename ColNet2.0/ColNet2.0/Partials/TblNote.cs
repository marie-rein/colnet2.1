using System.ComponentModel.DataAnnotations.Schema;

namespace ColNet2._0.Models;

public partial class TblNote
{
    [NotMapped]
    public string TypeTravail { get; set; }

    [NotMapped]
    public string Evaluation { get; set; }

    [NotMapped]
    public DateTime DateAssigne { get;set; }

    [NotMapped]
    public DateTime Echeance { get; set; }
}

