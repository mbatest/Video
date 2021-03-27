namespace VideoTapes
{
    using System.Data.Entity;

    public partial class Modèle : DbContext
    {
        public Modèle()
            : base("name=Modèle")
        {
        }
        public virtual DbSet<Keywords> Keywords { get; set; }
        public virtual DbSet<KeywordScene> KeywordScene { get; set; }
        public virtual DbSet<PrésenceScène> PrésenceScene { get; set; }
        public virtual DbSet<Lieux> Lieux { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Personne> Personne { get; set; }
        public virtual DbSet<Présence> Présence { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Scenes> Scenes { get; set; }
        public virtual DbSet<SequenceScene> SequenceScene { get; set; }
        public virtual DbSet<Shots> Shots { get; set; }
        public virtual DbSet<Videos> Videos { get; set; }
        public virtual DbSet<Villes> Villes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>()
                .HasMany(e => e.Présence)
                .WithOptional(e => e.Personne1)
                .HasForeignKey(e => e.Personne);

            modelBuilder.Entity<Shots>()
                .HasMany(e => e.Présence)
                .WithOptional(e => e.Shots)
                .HasForeignKey(e => e.Code_Séquence);

            modelBuilder.Entity<Shots>()
                .HasMany(e => e.SequenceScene)
                .WithOptional(e => e.Shots)
                .HasForeignKey(e => e.Code_Séquence);
        }
    }
}
