using ColNet2._0.Data;
using ColNet2._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ColNet2._0.Services
{
    public class AjoutUtilisateurService
    {
        private readonly IDbContextFactory<_2023Prog3WilliamMarieReineContext> _factory;
        protected bool estAjouter = false;

        public AjoutUtilisateurService(IDbContextFactory<_2023Prog3WilliamMarieReineContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<TblProgramme>> RemplirProgramme()
        {
            var dbContext = _factory.CreateDbContextAsync().Result;

            var programs = dbContext.Set<TblProgramme>()
                .FromSqlRaw("SELECT NoProgramme,NomProgramme FROM tblProgramme");

            return await programs.ToListAsync();
        }

        public async Task<bool> AjouterEtudiant(string nom, string prenom,string codeRegional, string numTel,string ville,int numRue,string nomRue,int prog,string pays,string pwd)
        {
            var dbcontext = _factory.CreateDbContextAsync().Result;

            var param1 = new SqlParameter("nom", nom);
            var param2 = new SqlParameter("prenom", prenom);
            var codeParam = new SqlParameter("codeRegional", codeRegional);
            var param3 = new SqlParameter("numeroTel", numTel);
            var param4 = new SqlParameter("nomVille", ville);
            var param5 = new SqlParameter("numeroRue", numRue);
            var param6 = new SqlParameter("nomRue", nomRue);
            var param7 = new SqlParameter("pays", pays);
            var param8 = new SqlParameter("programme", prog);           
            var param9 = new SqlParameter("motDePasse", pwd);
            var param10 = new SqlParameter();
            param10.ParameterName = "@reponse";
            param10.SqlDbType = System.Data.SqlDbType.Int;
            param10.Direction = System.Data.ParameterDirection.Output;

            var createEtudiant = dbcontext.Database.SqlQueryRaw<int>("EXEC Creer_Compte_Etudiant @nom,@prenom,@codeRegional,@numeroTel,@nomVille,@numeroRue,@nomRue,@pays,@programme,@motDePasse,@reponse OUT", param1,param2,codeParam,param3,param4,param5,param6,param7,param8,param9,param10).ToArray();

            if ((int)param10.Value == 1)
            {
                estAjouter = true;
            }
            else
            {
                estAjouter = false;
            }
            return estAjouter;
        }
        public async Task<bool> AjouterProf(string nom, string prenom, string codeRegional, string numTel, string ville, int numRue, string nomRue,string pays, string pwd)
        {

          

            var dbcontext = _factory.CreateDbContextAsync().Result;

            var param1 = new SqlParameter("nom", nom);
            var param2 = new SqlParameter("prenom", prenom);
            var codeParam = new SqlParameter("codeRegional", codeRegional);
            var param3 = new SqlParameter("numeroTel", numTel);
            var param4 = new SqlParameter("nomVille", ville);
            var param5 = new SqlParameter("numeroRue", numRue);
            var param6 = new SqlParameter("nomRue", nomRue);
            var param7 = new SqlParameter("pays", pays);
            var param8 = new SqlParameter("motDePasse", pwd); 
            var param9 = new SqlParameter();
            param9.ParameterName = "@reponse";
            param9.SqlDbType = System.Data.SqlDbType.Int;
            param9.Direction = System.Data.ParameterDirection.Output;

            var createProf = dbcontext.Database.SqlQueryRaw<int>("EXEC Creer_Compte_Professeur @nom,@prenom,@codeRegional,@numeroTel,@nomVille,@numeroRue,@nomRue,@pays,@motDePasse,@reponse OUT", param1, param2,codeParam, param3, param4, param5, param6,param7, param8,param9).ToArray();

            if ((int)param9.Value == 1)
            {
                estAjouter = true;
            }
            else
            {
                estAjouter = false;
            }
            return estAjouter;
           
        }
        public async Task<bool> AjouterAdmin(string nom, string prenom, string codeRegional, string numTel, string ville, int numRue, string nomRue,string pays, string pwd)
        {

            

            var dbcontext = _factory.CreateDbContextAsync().Result;

            var param1 = new SqlParameter("nom", nom);
            var param2 = new SqlParameter("prenom", prenom);
            var codeParam = new SqlParameter("codeRegional", codeRegional);
            var param3 = new SqlParameter("numeroTel", numTel);
            var param4 = new SqlParameter("nomVille", ville);
            var param5 = new SqlParameter("numeroRue", numRue);
            var param6 = new SqlParameter("nomRue", nomRue);
            var param7 = new SqlParameter("pays", pays);
            var param8 = new SqlParameter("motDePasse", pwd);
            var param9 = new SqlParameter();
            param9.ParameterName = "@reponse";
            param9.SqlDbType = System.Data.SqlDbType.Int;
            param9.Direction = System.Data.ParameterDirection.Output;

            var createAdmin = dbcontext.Database.SqlQueryRaw<int>("EXEC Creer_Compte_Admin @nom,@prenom,@codeRegional,@numeroTel,@nomVille,@numeroRue,@nomRue,@pays,@motDePasse,@reponse OUT", param1, param2,codeParam, param3, param4, param5, param6, param7,param8,param9).ToArray();

            if ((int)param9.Value == 1)
            {
                estAjouter = true;
            }
            else
            {
                estAjouter = false;
            }
            return estAjouter;
        }

        public bool VerifierPassword(string password)
        {
            string pattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*]).{8,}$";

            return Regex.IsMatch(password, pattern);
        }

        public bool verifierTexte(string userInput)
        {
            string pattern = "^[a-zA-Z-]+$";
            return Regex.IsMatch(userInput, pattern);
        }
    }
}
