using System.Data.Entity;

namespace NewModel
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<FccPosition> FccPositions { get; set; }
        public virtual DbSet<Foreign> Foreigns { get; set; }
        public virtual DbSet<Permit> Permits { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<YesNoDontKnow> YesNoDontKnows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
