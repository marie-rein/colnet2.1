using System.ComponentModel.DataAnnotations;

namespace ColNet2._0.CustomModels
{
    public class CheckResetPwd
    {

        [Required(ErrorMessage ="* Ce champs est obligatoire")]
        [Range(2200000,2600000, ErrorMessage ="Invalide Numero d'utilisateur")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "* Ce champs est obligatoire")]
        public string code { get; set; }

        [Required (ErrorMessage = "* Ce champs est obligatoire")]
        [DataType (DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*]).{8,}$", ErrorMessage = "Votre mot de passe doit contenir (1) Majuscule, (1) Minuscule, (1) chiffre, (1) Caractère special, Minimum (8) Caractères")]
        public string pwd { get; set; }

        [DataType (DataType.Password)]
        [Required (ErrorMessage = "* Ce champs est obligatoire")]
        public string confirmPwd { get; set; }
    }
}
