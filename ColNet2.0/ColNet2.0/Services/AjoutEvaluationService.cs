using ColNet2._0.Data;
using ColNet2._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Diagram;

namespace ColNet2._0.Services
{
    public class AjoutEvaluationService
    {
        private readonly IDbContextFactory<_2023Prog3WilliamMarieReineContext> _factory;

        public AjoutEvaluationService(IDbContextFactory<_2023Prog3WilliamMarieReineContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<TblCour>> RemplirCoursProfesseur(string emailProf)
        {
            var dbcontext = _factory.CreateDbContextAsync().Result;

            var param1 = new SqlParameter("courriel", emailProf);

            var coursProf = dbcontext.Set<TblCour>().FromSqlRaw("select noCour,nomCour,noProgramme,ponderation,session from tblCour as C join tblCoursProfesseur as CP on C.noCour = CP.noCours join tblProfesseur as P on P.noProf = CP.noProf where P.courrielProf = @courriel",param1).ToListAsync();

            return await coursProf;
        }

        public async Task AjoutEvaluation(int idCours,string titre,string type,string description,int point,DateTime dateAffectation, DateTime echeance)
        {
            var dbcontext = _factory.CreateDbContextAsync().Result;

            var travail = new TblTravaux();
            travail.NoCours = idCours;
            travail.Titre = titre;
            travail.TypeTravail = type;
            travail.Instruction = description;
            travail.DateAffectation = dateAffectation;
            travail.Echeance = echeance;
            dbcontext.TblTravauxes.Add(travail);
            await dbcontext.SaveChangesAsync();
           // await UpdateNoteTravail(travail.NoTravail,point);

            
        }

        public async Task UpdateNoteTravail(int noTravail, int point)
        {
            var dbcontext = _factory.CreateDbContextAsync().Result;


            //var notes = new TblNote();
            //notes.NoTravail = noTravail;
            //notes.NotesTravail = (short?)point;
            //dbcontext.TblNotes.Add(notes);
            var notes = await (from note in dbcontext.TblNotes
                        select note).ToListAsync();
            //    //.Where(note => note.NoTravail == noTravail).ToListAsync();

            //do
            //{
            //    notes.NotesTravail = (short?)point;
            //    note.NoTravail = noTravail;

            //} while (notes.Count != 0);
            ////foreach (var note in notes)
            //{
            //    
            //}

            await dbcontext.SaveChangesAsync();
        }
    }
}
