using System.ComponentModel.DataAnnotations;

namespace ColNet2._0.CustomModels
{
    public class AjoutEvaluationProperty
    {

        public string Titre { get; set; }

        public string TypeEvaluation { get; set; }

        public string Instruction { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateEvaluation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Echeance { get; set; }

        [Range(0,100)]
        public int pointMax { get; set; }
    }
}
