using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ColNet2._0.CustomModels
{
    public class CheckLogin
    {

        [Required (ErrorMessage = "* Le courriel est obligatoire")]
        [DataType(DataType.EmailAddress)]
        [BindProperty]
        public string email { get; set; } 



        [Required (ErrorMessage = "* le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [BindProperty]   
        public string password { get; set; }


    }
}
