using Microsoft.EntityFrameworkCore;
using MOS_Management.Models.ClassesCommunes;
using MOS_Management.Models.TypeDonnées.Complexes;
using MOS_Management.Models.TypeDonnées.Complexes.Complexes_;
using MOS_Management.Models.TypeDonnées.Simple;

namespace MOS_Management.API.Models
{
    public  class MOS_Communes_DbContext : DbContext
    {

        public MOS_Communes_DbContext(DbContextOptions<MOS_Communes_DbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agence>().ToTable("TR_Agence");
            modelBuilder.Entity<Nomenclature>().ToTable("TR_Nomenclature");
            modelBuilder.Entity<MosSystem>().ToTable("TR_System");
            modelBuilder.Entity<Code>().ToTable("TR_Code");
            modelBuilder.Entity<Identifiant>().ToTable("TR_Identifiant");
            modelBuilder.Entity<AutoriteEnregistrement>().ToTable("TR_AutoriteEnregistrement");
            modelBuilder.Entity<LangueParlee>().ToTable("TR_LangueParlee");

            modelBuilder.Entity<MosUri>().ToTable("TD_Uri");
            modelBuilder.Entity<Indicateur>().ToTable("TD_Indicateur");
            modelBuilder.Entity<MetaDonnee>().ToTable("TD_MetaDonnee");
            modelBuilder.Entity<PersonnePhysique>().ToTable("TD_PersonnePhysique");
        }

        public DbSet<Agence> Agences { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<MosSystem> Systems { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Identifiant> Identifiants { get; set; }
        public DbSet<AutoriteEnregistrement> AutoriteEnregistrements { get; set; }
        public DbSet<LangueParlee> LangueParlees { get; set; }

        public DbSet<MosUri> Uris { get; set; }
        public DbSet<Indicateur> Indicateurs { get; set; }
        public DbSet<MetaDonnee> MetaDonnees { get; set; }
        public DbSet<PersonnePhysique> PersonnePhysiques { get; set; }
    }
}
