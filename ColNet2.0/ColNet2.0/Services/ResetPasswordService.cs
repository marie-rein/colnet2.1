using ColNet2._0.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;

namespace ColNet2._0.Services
{
    public class ResetPasswordService
    {
        private IDbContextFactory<_2023Prog3WilliamMarieReineContext> _factory;

        public ResetPasswordService(IDbContextFactory<_2023Prog3WilliamMarieReineContext> factory)
        {
            _factory = factory;
        }

        public async Task<string> ResetPwd(int id, string password)
        {

            string message = string.Empty;

            var dbContext = _factory.CreateDbContextAsync().Result;
            var param1 = new SqlParameter("id", id);
            var param2 = new SqlParameter("motDePasse", password);
            var param3 = new SqlParameter();
            param3.ParameterName = "@pReponses";
            param3.SqlDbType = System.Data.SqlDbType.Int;
            param3.Direction = System.Data.ParameterDirection.Output;


            var update = dbContext.Database.SqlQueryRaw<int>("EXEC updatePassword @id,@motDePasse,@pReponses OUT", param1, param2, param3).ToArray();
            //dbContext.Database.ExecuteSqlRawAsync("EXEC updatePassword @id,@pReponse OUT", param1, param2);

            if ((int)param3.Value == 1)
            {
               
                    message = "Mot de passe a été modifié avec succés";   
            }
            else if ((int)param3.Value == -1)
            {
                message = "Une erreur est survenue. Veillez réesayer plus tard.";
            }

            return message;
        }

        public bool VerifierPassword(string password)
        {

            string pattern = "/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%\"^&*-]).{8,}$/";

            return  Regex.IsMatch(password,pattern);
        }

        public bool IsTokenExpired(string encodedToken)
        {
            try
            {
                
                DateTime expirationTime = (DateTime.Now.AddMinutes(30));

                return DateTime.Now > expirationTime;
            }
            catch
            {
                
                return true;
            }
        }

        public bool IsCodeValid(string userProvidedCode, string actualCode)
        {
            return string.Equals(userProvidedCode, actualCode);
        }

        public bool ValidateResetCode(string userProvidedCode)
        {
           
            string encodedToken = string.Empty ;         

            encodedToken = leService.expirationToken;
           
            if (encodedToken != null)
            {
                bool estValide = IsCodeValid(userProvidedCode, encodedToken);
                if (estValide)
                {
                    return true;
                }
                else { return false; }
               
            }
            else
            {
                return false;
            }
          
            
        }

    }
}
