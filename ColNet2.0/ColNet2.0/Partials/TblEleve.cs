
using Microsoft.AspNetCore.Mvc;
using ColNet2._0.CustomModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColNet2._0.Models
{
    public partial class TblEleve
    {
        [DataType(DataType.Password)]
        [Required]
        [BindProperty]
        [NotMapped]
        public string password { get; set; }

        [NotMapped]
        public string codeRegional { get; set; }
        [NotMapped]
        public string TypeTravail { get; internal set; }
    }
}
