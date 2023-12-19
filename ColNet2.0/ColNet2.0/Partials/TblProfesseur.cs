using System.ComponentModel.DataAnnotations.Schema;

namespace ColNet2._0.Models
{
    public partial class TblProfesseur
    {
        [NotMapped]
        public string password { get; set; }

        [NotMapped]
        public string codeRegional { get; set; }
    }
}
