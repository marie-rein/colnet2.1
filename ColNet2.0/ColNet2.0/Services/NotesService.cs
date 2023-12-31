﻿using ColNet2._0.Data;
using ColNet2._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ColNet2._0.Services
{
    public class NotesService
    {
        private readonly IDbContextFactory<_2023Prog3WilliamMarieReineContext> _factory;

        public NotesService(IDbContextFactory<_2023Prog3WilliamMarieReineContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<TblCour>> RemplirCours(string email)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;
            var param1 = new SqlParameter("CourrielEleve", email);
            ////var cours = dbContext.Set<TblCour>()
            ////    .FromSqlRaw("SELECT * FROM tblCour where ");

            var coursEleve = (from cours in dbContext.TblCours
                            from eleve in cours.NumeroDa
                            where eleve.CourrielEleve == email
                            select cours).ToListAsync();

            return await coursEleve;
        }
        public async Task<List<TblNote>> AfficherNotesEleve(int noCours, string email)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;

            var param1 = new SqlParameter("noCour", noCours);
            var param2 = new SqlParameter("CourrielEleve", email);


            //var notesEleve = dbContext.Set <TblNote>().FromSqlRaw("select T.titre,T.typeTravail,commentaire,notesEleve,moyenneEleve,notesTravail from tblTravaux as T join tblNotes as N on T.noTravail = N.noTravail join tblCour as C on C.noCour = T.noCours join tblEleve as E on E.numeroDA = N.numeroDA where E.courrielEleve = @CourrielEleve and C.noCour = @noCour", param2,param1).ToListAsync();

            var notes = (from note in dbContext.TblNotes
                         join travail in dbContext.TblTravauxes on note.NoTravail equals travail.NoTravail
                         join cour in dbContext.TblCours on travail.NoCours equals cour.NoCour
                         join eleve in dbContext.TblEleves on note.NumeroDa equals eleve.NumeroDa
                         where eleve.CourrielEleve == email && cour.NoCour == noCours
                         select new TblNote {TypeTravail= travail.TypeTravail,Evaluation = travail.Titre,DateAssigne = travail.DateAffectation,Echeance = travail.Echeance, NotesEleve = note.NotesEleve, MoyenneEleve = note.MoyenneEleve, NotesTravail = note.NotesTravail, Commentaire = note.Commentaire }).ToListAsync();

            //var typeTravail = from travail in dbContext.TblTravauxes
            return await notes;

        }
        public async Task<List<TblEleve>> RemplirEtudiant(int noCours)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;
            //from c in dbContext.TblCours
            //from e in c.NumeroDa

           
            var param1 = new SqlParameter("noCour", noCours);

            var coursEleve = (from cours in dbContext.TblCours
                              from eleve in cours.NumeroDa
                              where cours.NoCour == noCours
                              select eleve).ToList();

            //var coursEleve = dbContext.Set<TblEleve>()
            //    .FromSqlRaw("SELECT nomEleve,prenEleve,E.numeroDA FROM tblEleve AS E JOIN tblCoursEleve AS CE ON E.numeroDA = CE.numeroDA JOIN tblCour AS C ON C.noCour = CE.noCours where C.noCour = @noCours", param1);

            return  coursEleve;
        }

        public async Task<List<TblTravaux>> RecupererEvaluation(int noCours)
        {
            var dbcontext = _factory.CreateDbContextAsync().Result;

            var evaluations = (from cour in dbcontext.TblCours
                               from travail in cour.TblTravauxes
                               where cour.NoCour == noCours
                               select travail).ToListAsync();

            return await evaluations;
        }
        public async Task AjouterNoteEleve(int numeroDA,int numeroTravail,int noteTravail, int noteEleve,string commentaire)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;

            var nouvelleNote = new TblNote();

            nouvelleNote.NumeroDa = numeroDA;
            nouvelleNote.NoTravail = numeroTravail;
            nouvelleNote.NotesTravail = (short)noteTravail;
            nouvelleNote.NotesEleve = (short)noteEleve;
            nouvelleNote.Commentaire = commentaire;

            dbContext.TblNotes.Add(nouvelleNote);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<TblNote>> SelectionnerNotes(int numeroTravail)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;


            var lesNotes = (from note in dbContext.TblNotes
                            where note.NoTravail == numeroTravail
                            select note).ToListAsync();

            return await lesNotes;
        }

        public void UpdateNote(int numeroDa,int nouvelleNote)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;

            var updateNote = from note in dbContext.TblNotes
                             where note.NumeroDa == numeroDa
                             select note;

            foreach (var note in updateNote)
            {
                note.NotesEleve = (short)nouvelleNote;
            }

            dbContext.SaveChangesAsync();

        }

        public void DeleteNote(int numeroDa)
        {
            var dbContext = _factory.CreateDbContextAsync().Result;

            var deleteNote = from note in dbContext.TblNotes
                             where note.NumeroDa == numeroDa
                             select note;

            foreach (var note in deleteNote)
            {
                dbContext.TblNotes.Remove(note);
            }
            dbContext.SaveChangesAsync();
        }

    }
}
