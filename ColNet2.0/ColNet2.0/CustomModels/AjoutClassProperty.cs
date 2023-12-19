using Microsoft.AspNetCore.Mvc;
using ColNet2._0.Models;
using System.ComponentModel.DataAnnotations;

namespace ColNet2._0.CustomModels
{
    public class AjoutClassProperty
    {
        [BindProperty]
        [Required (ErrorMessage = "Ce champs ne doit pas etre vide")]
        [RegularExpression("^[a-zA-Z-]+$", ErrorMessage = "Le nom ne doit pas contenir des caractères speciaux ni des chiffres")]
        public string Nom { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ce champs ne doit pas etre vide")]
        [RegularExpression("^[a-zA-Z-]+$", ErrorMessage = "Le nom ne doit pas contenir des caractères speciaux ni des chiffres")]
        public string Prenom { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ce champs ne doit pas etre vide")]
        public string Code { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ce champs ne doit pas etre vide")]
        public string NumTel { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ce champs ne doit pas etre vide")]
        public string NomRue { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ce champs ne doit pas etre vide")]
        public string NomVille { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ce champs ne doit pas etre vide")]
        public int NumRue { get; set; }

        [BindProperty]
        [Required (ErrorMessage ="Ce champs ne doit pas etre vide")]
        public string pays { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Ce champs ne doit pas etre vide")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*]).{8,}$", ErrorMessage = "Votre mot de passe doit contenir (1) Majuscule, (1) Minuscule, (1) chiffre, (1) Caractère special, Minimum (8) Caractères")]
        public string password { get; set; }
        


      
        public TblEleve ToEleve()
        {
            TblEleve eleve = new TblEleve()
            {
                NomEleve = Nom,
                PrenEleve = Prenom,
                codeRegional = Code,
                TelEleve = NumTel,
                NomRueEleve = NomRue,
                NoRueEleve = (short)NumRue,
                VilleEleve = NomVille,
                Pays = pays,
                password = password

            };
            return eleve;
        }

        public TblProfesseur ToProf()
        {
            TblProfesseur prof = new TblProfesseur()
            {
                NomProf = Nom,
                PrenProf = Prenom,
                codeRegional=Code,
                TelProf = NumTel,
                VilleProf = NomVille,
                NoRueProf = (short)NumRue,
                NomRueProf = NomRue,
                Pays = pays, 
                password = password
            };
            return prof;
        }

        public TblAdmin ToAdmin()
        {
            TblAdmin admin = new TblAdmin()
            {
                NomAdmin = Nom,
                PrenAdmin = Prenom,
                codeRegional = Code,
                NumTelAdmin = NumTel,
                VilleAdmin = NomVille,
                NoRueAdmin = (short)NumRue,
                NomRueAdmin = NomRue,
                Pays = pays,
                password = password
            };

           return admin;
        }
       

    }
}
