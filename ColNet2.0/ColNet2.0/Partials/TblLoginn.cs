using ColNet2._0.Authentification;
using ColNet2._0.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ColNet2._0.Models
{
    public partial class TblLogin
    {
        private string role;

        public string Role
        {
            get
            {

                if (TblAdmins.Count > 0)
                {
                    return "admin";
                }
                else if (TblEleves.Count > 0)
                {
                    return "Etudiant";
                }
                else if (TblProfesseurs.Count > 0)
                {
                    return "Professeur";
                }

                return null;
            }
        }
        public string SetUserRole(UserSession userSession)
        {
            return userSession.role = Role;
        }

    }
}
