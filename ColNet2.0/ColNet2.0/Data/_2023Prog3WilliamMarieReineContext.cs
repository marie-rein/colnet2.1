using System;
using System.Collections.Generic;
using ColNet2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace ColNet2._0.Data;

public partial class _2023Prog3WilliamMarieReineContext : DbContext
{
    public _2023Prog3WilliamMarieReineContext()
    {
    }

    public _2023Prog3WilliamMarieReineContext(DbContextOptions<_2023Prog3WilliamMarieReineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblCour> TblCours { get; set; }

    public virtual DbSet<TblEleve> TblEleves { get; set; }

    public virtual DbSet<TblLogin> TblLogins { get; set; }

    public virtual DbSet<TblNote> TblNotes { get; set; }

    public virtual DbSet<TblPeriode> TblPeriodes { get; set; }

    public virtual DbSet<TblProfesseur> TblProfesseurs { get; set; }

    public virtual DbSet<TblProgramme> TblProgrammes { get; set; }

    public virtual DbSet<TblTravaux> TblTravauxes { get; set; }

    public virtual DbSet<VueHoraire> VueHoraires { get; set; }

    public virtual DbSet<VueTravailEtudiant> VueTravailEtudiants { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity.HasKey(e => e.NoAdmin).HasName("PK__tblAdmin__10634AD8CD53354E");

            entity.Property(e => e.NoAdmin).ValueGeneratedNever();

            entity.HasOne(d => d.IdLoginNavigation).WithMany(p => p.TblAdmins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblAdmin__idLogi__398D8EEE");
        });

        modelBuilder.Entity<TblCour>(entity =>
        {
            entity.HasKey(e => e.NoCour).HasName("PK__tblCour__0C3F93111F2D4B12");

            entity.HasOne(d => d.NoProgrammeNavigation).WithMany(p => p.TblCours)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCour__noProgr__3A81B327");

            entity.HasMany(d => d.NumeroDa).WithMany(p => p.NoCours)
                .UsingEntity<Dictionary<string, object>>(
                    "TblCoursEleve",
                    r => r.HasOne<TblEleve>().WithMany()
                        .HasForeignKey("NumeroDa")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tblCoursE__numer__3F466844"),
                    l => l.HasOne<TblCour>().WithMany()
                        .HasForeignKey("NoCours")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tblCoursE__noCou__3E52440B"),
                    j =>
                    {
                        j.HasKey("NoCours", "NumeroDa").HasName("PK__tblCours__EFA0B420BAD3EF15");
                        j.ToTable("tblCoursEleve");
                        j.IndexerProperty<int>("NoCours").HasColumnName("noCours");
                        j.IndexerProperty<int>("NumeroDa").HasColumnName("numeroDA");
                    });
        });

        modelBuilder.Entity<TblEleve>(entity =>
        {
            entity.HasKey(e => e.NumeroDa).HasName("PK__tblEleve__405E0067E473754D");

            entity.Property(e => e.NumeroDa).ValueGeneratedNever();

            entity.HasOne(d => d.IdLoginNavigation).WithMany(p => p.TblEleves)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblEleve__idLogi__38996AB5");

            entity.HasOne(d => d.NumProgrammeNavigation).WithMany(p => p.TblEleves)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblEleve__numPro__37A5467C");
        });

        modelBuilder.Entity<TblLogin>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__tblLogin__068B3EBBF72C4EC6");

            entity.Property(e => e.IdLogin).ValueGeneratedNever();
            entity.Property(e => e.Password).IsFixedLength();
        });

        modelBuilder.Entity<TblNote>(entity =>
        {
            entity.HasKey(e => new { e.NoTravail, e.NumeroDa }).HasName("PK__tblNotes__578320C9BAB0307B");

            entity.ToTable("tblNotes", tb =>
                {
                    tb.HasTrigger("tr_verifier_max");
                    tb.HasTrigger("updates_moyenneNotes");
                });

            entity.HasOne(d => d.NoTravailNavigation).WithMany(p => p.TblNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblNotes__noTrav__4222D4EF");

            entity.HasOne(d => d.NumeroDaNavigation).WithMany(p => p.TblNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblNotes__numero__412EB0B6");
        });

        modelBuilder.Entity<TblPeriode>(entity =>
        {
            entity.HasKey(e => e.NoPeriode).HasName("PK__tblPerio__9BCF500054D1A8FF");

            entity.HasOne(d => d.NoCoursNavigation).WithMany(p => p.TblPeriodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblPeriod__noCou__403A8C7D");
        });

        modelBuilder.Entity<TblProfesseur>(entity =>
        {
            entity.HasKey(e => e.NoProf).HasName("PK__tblProfe__33CA0FA5A4FD5188");

            entity.Property(e => e.NoProf).ValueGeneratedNever();

            entity.HasOne(d => d.IdLoginNavigation).WithMany(p => p.TblProfesseurs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblProfes__idLog__3B75D760");

            entity.HasMany(d => d.NoCours).WithMany(p => p.NoProfs)
                .UsingEntity<Dictionary<string, object>>(
                    "TblCoursProfesseur",
                    r => r.HasOne<TblCour>().WithMany()
                        .HasForeignKey("NoCours")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tblCoursP__noCou__3D5E1FD2"),
                    l => l.HasOne<TblProfesseur>().WithMany()
                        .HasForeignKey("NoProf")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tblCoursP__noPro__3C69FB99"),
                    j =>
                    {
                        j.HasKey("NoProf", "NoCours").HasName("PK__tblCours__4B705AE720E6E90F");
                        j.ToTable("tblCoursProfesseur");
                        j.IndexerProperty<int>("NoProf").HasColumnName("noProf");
                        j.IndexerProperty<int>("NoCours").HasColumnName("noCours");
                    });
        });

        modelBuilder.Entity<TblProgramme>(entity =>
        {
            entity.HasKey(e => e.NoProgramme).HasName("PK__tblProgr__E44C5D37D96689F7");
        });

        modelBuilder.Entity<TblTravaux>(entity =>
        {
            entity.HasKey(e => e.NoTravail).HasName("PK__tblTrava__3386C0CF5F65CC6C");

            entity.HasOne(d => d.NoCoursNavigation).WithMany(p => p.TblTravauxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblTravau__noCou__4316F928");
        });

        modelBuilder.Entity<VueHoraire>(entity =>
        {
            entity.ToView("vueHoraire");
        });

        modelBuilder.Entity<VueTravailEtudiant>(entity =>
        {
            entity.ToView("vueTravailEtudiant");
        });
        modelBuilder.HasSequence("AddIdLogin").StartsAt(2400000L);
        modelBuilder.HasSequence("LoginAdminSequence").StartsAt(2500000L);
        modelBuilder.HasSequence("LoginEtudiantSequence").StartsAt(2200000L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
