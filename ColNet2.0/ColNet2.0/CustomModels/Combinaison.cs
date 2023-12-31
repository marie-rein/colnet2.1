﻿namespace ColNet2._0.CustomModels
{
    public class Combinaison
    {


        public int NumeroDa { get; set; }
        public int NoTravail { get; set; }
        public string NomEleve { get; set; }
        public string PrenEleve { get; set; }
        public string Titre { get; set; }
        public string Type { get; set; }
        public DateTime dueDate { get; set; }
        public short noteEleve { get; set; }
        public short moyenne { get; set; }
        public short noteTravail { get; set; }
        public string commentaire { get; set; }
        public Combinaison() { }
        public Combinaison(int numeroDa, int noTravail, string nomEleve, string prenEleve, short noteEleve, short moyenne, short noteTravail, string commentaire)
        {
            NumeroDa = numeroDa;
            NoTravail = noTravail;
            NomEleve = nomEleve;
            PrenEleve = prenEleve;
            this.noteEleve = noteEleve;
            this.moyenne = moyenne;
            this.noteTravail = noteTravail;
            this.commentaire = commentaire;
        }
    }
}
