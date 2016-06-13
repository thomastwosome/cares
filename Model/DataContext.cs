using System.Data.Entity;

namespace Model
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=EdcaresConnection")
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Ethnicity> Ethnicities { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<CredentialType> CredentialTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Site>()
            //    .HasMany(e => e.Classrooms)
            //    .WithRequired(e => e.Site)
            //    .WillCascadeOnDelete();

            modelBuilder.Entity<Application>()
                .HasMany(x => x.Ethnicities)
                .WithMany(x => x.Applications)
                .Map(m => m.ToTable("AppEthnicities").MapLeftKey("ApplicationId").MapRightKey("EthnicityId"));

            modelBuilder.Entity<Application>()
                .HasMany(x => x.Programs)
                .WithMany(x => x.Applications)
                .Map(m => m.ToTable("AppPrograms").MapLeftKey("ApplicationId").MapRightKey("ProgramId"));

            modelBuilder.Entity<Application>()
                .HasMany(x => x.Degrees)
                .WithMany(x => x.Applications)
                .Map(m => m.ToTable("AppDegrees").MapLeftKey("ApplicationId").MapRightKey("DegreeId"));

            modelBuilder.Entity<Application>()
                .HasMany(x => x.CredentialTypes)
                .WithMany(x => x.Applications)
                .Map(m => m.ToTable("AppCredentialTypes").MapLeftKey("ApplicationId").MapRightKey("CredentialTypeId"));
        }
    }
}