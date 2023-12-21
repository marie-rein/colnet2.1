using ColNet2._0.Authentification;
using ColNet2._0.CustomModels;
using ColNet2._0.Data;
using ColNet2._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Text;

namespace ColNet2._0.Services
{
    public class LoginService
    {
        private readonly IDbContextFactory<_2023Prog3WilliamMarieReineContext> _factory;
        public UserSession session { get; set; } = new UserSession();
        public TblLogin login { get; set; } = new TblLogin();

        public LoginService(IDbContextFactory<_2023Prog3WilliamMarieReineContext> factory)
        {
            _factory = factory;
        }


        public async Task<bool> SelectUserLogin(CheckLogin check, CustomAuthenticationStateProvider custom)
        {
            //int id;
            bool estLogger = false;

            var dbContext = _factory.CreateDbContextAsync().Result;
            var param1 = new SqlParameter("courriel", check.email);
            var param2 = new SqlParameter("passwords", check.password);
            var param3 = new SqlParameter();
            param3.ParameterName = "@reponse";
            param3.SqlDbType = System.Data.SqlDbType.Int;
            param3.Direction = System.Data.ParameterDirection.Output;

            var id = dbContext.Database.SqlQueryRaw<int>("EXEC Verifier_Utilisateur @courriel,@passwords,@reponse OUT", param1, param2,param3).ToArray();

            var estAdmin = dbContext.TblAdmins.Any(admin => admin.CourrielAdmin == check.email);
            var estEtud = dbContext.TblEleves.Any(student => student.CourrielEleve == check.email);
            var estProf = dbContext.TblProfesseurs.Any(prof => prof.CourrielProf == check.email);

            if ((int)param3.Value == 1)
            {

                //string userRole = login.SetUserRole(session);

                if (estEtud)
                {
                    var nomEtudiant = (from users in dbContext.TblEleves
                                      where users.CourrielEleve == check.email
                                      select users.NomEleve).FirstOrDefault();
                    
                    await custom.UpdateAuthenticationState(new UserSession { nom = nomEtudiant, role = "etudiant", email=check.email});
                    estLogger = true;

                }
                else if (estAdmin)
                {
                    var nomAdmin = (from users in dbContext.TblAdmins
                                   where users.CourrielAdmin == check.email
                                   select users.NomAdmin).FirstOrDefault();
                    await custom.UpdateAuthenticationState(new UserSession { nom = nomAdmin, role = "admin", email = check.email });
                    estLogger = true;
                }
                else if(estProf)
                {
                    var nomProf = (from users in dbContext.TblProfesseurs
                                   where users.CourrielProf == check.email
                                   select users.NomProf).FirstOrDefault();
                    await custom.UpdateAuthenticationState(new UserSession { nom = nomProf, role = "professeur" , email = check.email });
                    estLogger = true;
                }
                else
                {
                    estLogger = false;
                }  

            }
            else if((int)param3.Value == -1)
            {
                estLogger = false;
                await custom.UpdateAuthenticationState(null);
            }

            return estLogger;


        }


    }
}
