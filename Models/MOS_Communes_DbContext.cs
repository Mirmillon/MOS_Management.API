using Microsoft.EntityFrameworkCore;
using MOS_Management.Models.AccordDossier;
using MOS_Management.Models.AuthentificationDossier;
using MOS_Management.Models.Autorisation;
using MOS_Management.Models.ClassesCommunes;
using MOS_Management.Models.OrganisationDossier;
using MOS_Management.Models.PersonnePriseChargeDossier;
using MOS_Management.Models.ProfessionnelDossier;
using MOS_Management.Models.StructureDossier;
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

            /*
            ACCORD
            */
            modelBuilder.Entity<AutorisationExercice>().ToTable("TD_AutorisationExercice");
            modelBuilder.Entity<Convention>().ToTable("TD_Convention");
            modelBuilder.Entity<LicenceExploitation>().ToTable("TD_LicenceExploitation");

            /*
            AUTHENTIFICATION
            */
            modelBuilder.Entity<CarteProfessionnelle>().ToTable("TD_CarteProfessionnelle");
            modelBuilder.Entity<Certificat>().ToTable("TD_Certificat");

            /*
            AUTORISATION
            */
            modelBuilder.Entity<ActiviteSanitaireAutorisee>().ToTable("TD_ActiviteSanitaireAutorisee");
            modelBuilder.Entity<DisciplineSocialeAutorisee>().ToTable("TD_DisciplineSocialeAutorisee");
            modelBuilder.Entity<ImplementationActiviteSanitaireAutorisee>().ToTable("TD_ImplementationActiviteSanitaireAutorisee");

            /*
            COMMUN
            */
            modelBuilder.Entity<Adresse>().ToTable("TD_Adresse");
            modelBuilder.Entity<AutoriteEnregistrement>().ToTable("TR_AutoriteEnregistrement");
            modelBuilder.Entity<BoileLettreMMS>().ToTable("TD_BoileLettreMMS");
            modelBuilder.Entity<CapaciteAcceuil>().ToTable("TD_CapaciteAcceuilS");
            modelBuilder.Entity<CapaciteAcceuilCrise>().ToTable("TD_CapaciteAcceuilCrise");
            modelBuilder.Entity<CapaciteHabitation>().ToTable("TD_CapaciteHabitation");
            modelBuilder.Entity<ConceptCode>().ToTable("TD_ConceptCode");
            modelBuilder.Entity<Contact>().ToTable("TD_Contact");
            modelBuilder.Entity<CoordonneeGeographique>().ToTable("TD_CoordonneeGeographique");
            modelBuilder.Entity<Diplome>().ToTable("TR_Diplome");
            modelBuilder.Entity<DivisionTerritorial>().ToTable("TR_DivisionTerritoriale");
            modelBuilder.Entity<Evenement>().ToTable("TD_Evenement");
            modelBuilder.Entity<Horaire>().ToTable("TD_Horaire");
            modelBuilder.Entity<LangueParlee>().ToTable("TR_LangueParlee");
            modelBuilder.Entity<Lieu>().ToTable("TD_Lieu");
            modelBuilder.Entity<MetaDonnee>().ToTable("TD_MetaDonnee");
            modelBuilder.Entity<Patientele>().ToTable("TD_Patientele");
            modelBuilder.Entity<PersonnePhysique>().ToTable("TD_PersonnePhysique");
            modelBuilder.Entity<RessourceMaterielle>().ToTable("TD_RessourceMaterielle");
            modelBuilder.Entity<Tarif>().ToTable("TD_Tarif");
            modelBuilder.Entity<TeleCommunication>().ToTable("TD_TeleCommunication");
            modelBuilder.Entity<Zone>().ToTable("TD_Zone");
            /*
            ORGANISATION
           */
            modelBuilder.Entity<ActiviteOperationnelle>().ToTable("TD_ActiviteOperationnellee");
            modelBuilder.Entity<OrganisationInterne>().ToTable("TD_OrganisationInterne");
            modelBuilder.Entity<Organisation_Activite>().ToTable("TJ_Organisation_Activite");
            modelBuilder.Entity<Sectorisation>().ToTable("TD_Sectorisation");
            /*
            PERSONNE
           */
            modelBuilder.Entity<PersonnePriseEnCharge_Professionnel>().ToTable("TJ_Soignant_Soigne");
            /*
            PROFESSIONNEL
           */
            modelBuilder.Entity<AttributionParticuliére>().ToTable("TD_AttributionParticuliéree");
            modelBuilder.Entity<ExerciceProfessionnel>().ToTable("TD_ExerciceProfessionnele");
            modelBuilder.Entity<InscriptionOrdre>().ToTable("TD_InscriptionOrdre");
            modelBuilder.Entity<NiveauFormation>().ToTable("TD_NiveauFormation");
            modelBuilder.Entity<SavoirFaire>().ToTable("TD_SavoirFairee");
            modelBuilder.Entity<SituationEnExercice>().ToTable("TD_SituationEnExercice");
            modelBuilder.Entity<SituationOperationnelle>().ToTable("TD_SituationOperationnelle");

            /*
            STRUCTURE
            */
            modelBuilder.Entity<EntiteGeographique>().ToTable("TD_EntiteGeographique");
            modelBuilder.Entity<EntiteJuridique>().ToTable("TD_EntiteJuridique");
            /*
            TYPE COMPLEXE
            */

            modelBuilder.Entity<Agence>().ToTable("TR_Agence");
            modelBuilder.Entity<Nomenclature>().ToTable("TR_Nomenclature");
            modelBuilder.Entity<MosSystem>().ToTable("TR_System");


            modelBuilder.Entity<Code>().ToTable("TR_Code");
            modelBuilder.Entity<MosDateTime>().ToTable("TD_Date");
            modelBuilder.Entity<Identifiant>().ToTable("TR_Identifiant");
            modelBuilder.Entity<Indicateur>().ToTable("TD_Indicateur");
            modelBuilder.Entity<Mesure>().ToTable("TD_Mesure");
            modelBuilder.Entity<Montant>().ToTable("TD_Montant");
            modelBuilder.Entity<Numerique>().ToTable("TD_Numerique");
            modelBuilder.Entity<ObjetBinaire>().ToTable("TD_ObjetBinaire");
            modelBuilder.Entity<Texte>().ToTable("TD_Texte");
          

            /*
            TYPR SIMPLE
            */
            modelBuilder.Entity<MosUri>().ToTable("TD_Uri");

            /*
            FK
            */

            modelBuilder.Entity<EquipementMaterielLourdAutorise>()
                        .HasOne<EntiteGeographique>()
                        .WithMany()
                        .HasForeignKey(p => p.EntiteGeographiqueId);


            /*
            TABLE JONCTION
            */
            //SOIGNANT-SOIGNE
            modelBuilder.Entity<PersonnePriseEnCharge_Professionnel>()
                .HasKey(t => new { t.PersonnePriseChargeId, t.ProfessionnelId });

            modelBuilder.Entity<PersonnePriseEnCharge_Professionnel>()
                .HasOne(pt => pt.Professionnel)
                .WithMany(p => p.Soignant_Soignes)
                .HasForeignKey(pt => pt.ProfessionnelId);

            modelBuilder.Entity <PersonnePriseEnCharge_Professionnel>()
                .HasOne(pt => pt.PersonnePriseCharge)
                .WithMany(t => t.Soignant_Soignes)
                .HasForeignKey(pt => pt.PersonnePriseChargeId);

            //Organisation_Activite
            modelBuilder.Entity<Organisation_Activite>()
               .HasKey(t => new { t.OrganisationInterneId, t.ActiviteOperationelleId });

            modelBuilder.Entity<Organisation_Activite>()
                .HasOne(pt => pt.OrganisationInterne)
                .WithMany(p => p.Organisation_Activites)
                .HasForeignKey(pt => pt.OrganisationInterneId);

            modelBuilder.Entity<Organisation_Activite>()
                .HasOne(pt => pt.ActiviteOperationelle)
                .WithMany(t => t.Organisation_Activites)
                .HasForeignKey(pt => pt.ActiviteOperationelleId);
        }

        /*
        ACCORD
        */
        public DbSet<AutorisationExercice> AutorisationExercices { get; set; }
        public DbSet<Convention> Conventions { get; set; }
        public DbSet<LicenceExploitation> LicenceExploitations { get; set; }

        /*
        AUTHENTIFICATION
        */
        public DbSet<CarteProfessionnelle> CarteProfessionnelles { get; set; }
        public DbSet<Certificat> Certificats { get; set; }
        /*
        AUTORISATION
        */
        public DbSet<ActiviteSanitaireAutorisee> ActiviteSanitaireAutorisees { get; set; }
        public DbSet<DisciplineSocialeAutorisee> DisciplineSocialeAutorisees { get; set; }
        public DbSet<ImplementationActiviteSanitaireAutorisee> ImplementationActiviteSanitaireAutorisees { get; set; }

        /*
        COMMUN
        */
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<AutoriteEnregistrement> AutoriteEnregistrements { get; set; }
        public DbSet<BoileLettreMMS> BoileLettreMMSs { get; set; }
        public DbSet<CapaciteAcceuil> CapaciteAcceuils { get; set; }
        public DbSet<CapaciteAcceuilCrise> CapaciteAcceuilCrises { get; set; }
        public DbSet<CapaciteHabitation> CapaciteHabitations { get; set; }
        public DbSet<ConceptCode> ConceptCodes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CoordonneeGeographique> CoordonneeGeographiques { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<DivisionTerritorial> DivisionTerritoriales { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Horaire> Horaires { get; set; }
        public DbSet<LangueParlee> LangueParlees { get; set; }
        public DbSet<Lieu> Lieus { get; set; }
        public DbSet<MetaDonnee> MetaDonnees { get; set; }
        public DbSet<Patientele> Patienteles { get; set; }
        public DbSet<PersonnePhysique> PersonnePhysiques { get; set; }
        public DbSet<RessourceMaterielle> RessourceMaterielles { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<TeleCommunication> TeleCommunications { get; set; }
        public DbSet<Zone> Zones { get; set; }
        /*
        ORGANISATION
       */
        public DbSet<Organisation_Activite> Organisation_Activites { get; set; }
        public DbSet<OrganisationInterne> OrganisationInternes { get; set; }
        public DbSet<ActiviteOperationnelle> ActiviteOperationnelles { get; set; }
        public DbSet<Sectorisation> Sectorisations { get; set; }
       
        /*
        PERSONNE PRISE EN CHARGE
       */
        public DbSet<PersonnePriseEnCharge_Professionnel> Soignant_Soignes { get; set; }

        /*
        PROFESSIONNEL
       */
        public DbSet<AttributionParticuliére> AttributionParticuliéres { get; set; }
        public DbSet<ExerciceProfessionnel> ExerciceProfessionnels { get; set; }
        public DbSet<InscriptionOrdre> InscriptionOrdres { get; set; }
        public DbSet<NiveauFormation> NiveauFormations { get; set; }
        public DbSet<SavoirFaire> SavoirFaires { get; set; }
        public DbSet<SituationEnExercice> SituationEnExercices { get; set; }
        public DbSet<SituationOperationnelle> SituationOperationnelles { get; set; }

        /*
        STRUCTURE
        */
        public DbSet<EntiteGeographique> EntiteGeographiques { get; set; }
        public DbSet<EntiteJuridique> EntiteJuridiques { get; set; }

        /*
        TYPE COMPLEXE
        */
        public DbSet<Agence> Agences { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<MosSystem> Systems { get; set; }


        public DbSet<Code> Codes { get; set; }
        public DbSet<MosDateTime> DateTimes { get; set; }
        public DbSet<Identifiant> Identifiants { get; set; }
        public DbSet<Indicateur> Indicateurs { get; set; }
        public DbSet<Mesure> Mesure { get; set; }
        public DbSet<Montant> Montants { get; set; }
        public DbSet<Numerique> Numeriques { get; set; }
        public DbSet<ObjetBinaire> ObjetBinaires { get; set; }
        public DbSet<Texte> Textes { get; set; }
       


        
       
       

        /*
        TYPE SIMPLE
        */
        public DbSet<MosUri> Uris { get; set; }







       
       
        
       
       



    }
}
