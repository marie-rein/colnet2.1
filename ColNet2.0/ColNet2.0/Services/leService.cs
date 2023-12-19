using ColNet2._0.Data;
using ColNet2._0.Models;
using ColNet2._0.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System;

namespace ColNet2._0.Services
{

    public class leService
    {
        public static string expirationToken { get; set; }
        private static readonly Random random = new Random();

        private IDbContextFactory<_2023Prog3WilliamMarieReineContext> _factory;
        // private readonly UserManager<IdentityUser> _userManager;

        public leService() { }
        public leService(IDbContextFactory<_2023Prog3WilliamMarieReineContext> factory)
        {
            _factory = factory;
            // _userManager = userManager;

        }


        //public async Task<string> VerifieEmail(string email)
        //{
        //    var dbContext = _factory.CreateDbContextAsync().Result;

        //    var estAdmin = dbContext.TblAdmins.Any(admin => admin.CourrielAdmin == email);
        //    var estEtud = dbContext.TblEleves.Any(student => student.CourrielEleve == email);
        //    var estProf = dbContext.TblProfesseurs.Any(prof => prof.CourrielProf == email);

        //    var param1 = new SqlParameter("@courrielParam", email);

        //    if (estAdmin)
        //    {
        //        var adminEmail = from admin in dbContext.TblAdmins
        //                         where admin.CourrielAdmin == email
        //                         select admin.CourrielAdmin;
        //        return adminEmail.ToString();
        //    }
        //    else if (estEtud)
        //    {
        //        var etuEmail = from etudiant in dbContext.TblEleves
        //                       where etudiant.CourrielEleve == email
        //                       select etudiant.CourrielEleve;
        //        return etuEmail.ToString();
        //    }
        //    else if (estProf)
        //    {
        //        var profEmail = from prof in dbContext.TblProfesseurs
        //                        where prof.CourrielProf == email
        //                        select prof.CourrielProf;
        //        return profEmail.ToString();
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        public async Task<string> VerifieEmail(string email)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;

            var adminEmail = await dbContext.TblAdmins
                .Where(admin => admin.CourrielAdmin == email)
                .Select(admin => admin.CourrielAdmin)
                .FirstOrDefaultAsync();

            if (adminEmail != null)
            {
                return adminEmail;
            }

            var etuEmail = await dbContext.TblEleves
                .Where(student => student.CourrielEleve == email)
                .Select(student => student.CourrielEleve)
                .FirstOrDefaultAsync();

            if (etuEmail != null)
            {
                return etuEmail;
            }

            var profEmail = await dbContext.TblProfesseurs
                .Where(prof => prof.CourrielProf == email)
                .Select(prof => prof.CourrielProf)
                .FirstOrDefaultAsync();

            if (profEmail != null)
            {
                return profEmail;
            }

            return null;
        }


        public async Task<bool> SendPasswordResetLinkAsync(string email,string link)
        {
            bool emailSent = false;
            try
            {
                if (IsValidEmail(email))
                {
                     expirationToken = GenerateExpirationToken();
                    //string resetLink = $"{navManager.BaseUri}resetPassword/"; // The link without the token

                    string emailBody = $"Clicker <a href='{link}'> <strong>ICI</strong> </a> pour changer votre mot de passe. Voici le code de vérification : {HttpUtility.UrlEncode(expirationToken)}";

                    await SendEmailAsync(email, "Réinitialiser votre Mot de Passe", emailBody);

                    emailSent = true;
                }
            }
            catch (Exception)
            {
                emailSent = false;
            }
            return emailSent;
        }

       



        private async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            using (var client = new SmtpClient("smtp.office365.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("colnet2.0@outlook.com", "Colnet@2023");
                client.EnableSsl = true;

                var message = new MailMessage("colnet2.0@outlook.com", email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                };

                await client.SendMailAsync(message);
            }
        }
        public string  GenerateExpirationToken()
        {
           // DateTime expirationTime = DateTime.Now.AddMinutes(30);
            string numericToken = GenerateNumericToken(5); 
            return numericToken;
        }
        //private string GenerateExpirationToken()
        //{
        //    DateTime expirationTime = DateTime.Now.AddMinutes(30);
        //    return Convert.ToBase64String(Encoding.UTF8.GetBytes(expirationTime.ToString()));
        //}

        public string GenerateNumericToken(int length)
        {
            const string allowedChars = "0123456789";

            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }

            return new string(result);
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
               
                string pattern = "^[0-9]+@[^\\s@]+\\.[^\\s@]+$";
               
                return Regex.IsMatch(email,pattern);
            }
            catch
            {
                return false;
            }
        }

    }
}
