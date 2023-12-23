using ColNet2._0.Data;
using ColNet2._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static ColNet2._0.Pages.Horaire;

namespace ColNet2._0.Services
{
    public class HoraireService
    {
        private readonly IDbContextFactory<_2023Prog3WilliamMarieReineContext> _factory;
        protected bool estAfficher = false;

        public HoraireService(IDbContextFactory<_2023Prog3WilliamMarieReineContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<VueHoraire>> RemplirProgramme(string email)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;
            var param1 = new SqlParameter("courriel", email);

            var programs = dbContext.Set<VueHoraire>()
                .FromSqlRaw("SELECT * FROM vueHoraire where Courriel = @courriel order by Jours asc",param1);

            return programs.ToList();
        }



        public async Task<bool> AfficherHoraire(string nomCour, string session, string HeureDebut, string HeureFin, string Jours, int locale)
        {
            var dbcontext = _factory.CreateDbContextAsync().Result;

            var param1 = new SqlParameter("nomCour", nomCour);
            var param2 = new SqlParameter("session", session);
            var codeParam = new SqlParameter("HeureDebut", HeureDebut);
            var param3 = new SqlParameter("HeureFin", HeureFin);
            var param4 = new SqlParameter("Jours", Jours);
            var param5 = new SqlParameter("locale", locale);
            var param6 = new SqlParameter();
            param6.ParameterName = "@reponse";
            param6.SqlDbType = System.Data.SqlDbType.Int;
            param6.Direction = System.Data.ParameterDirection.Output;



            if ((int)param6.Value == 1)
            {
                estAfficher = true;
            }
            else
            {
                estAfficher = false;
            }
            return estAfficher;
        }
    }
}

