namespace MusicWPF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicDB : DbContext
    {
        public MusicDB()
            : base("name=MusicDB")
        {
        }

        public virtual DbSet<ALBUMS> ALBUMS { get; set; }
        public virtual DbSet<ARTISTS> ARTISTS { get; set; }
        public virtual DbSet<SONGS> SONGS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALBUMS>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ALBUMS>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<ALBUMS>()
                .HasMany(e => e.SONGS)
                .WithOptional(e => e.ALBUMS)
                .HasForeignKey(e => e.ID_Album);

            modelBuilder.Entity<ARTISTS>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ARTISTS>()
                .Property(e => e.Name_2)
                .IsUnicode(false);

            modelBuilder.Entity<ARTISTS>()
                .HasMany(e => e.ALBUMS)
                .WithOptional(e => e.ARTISTS)
                .HasForeignKey(e => e.ID_Artist);

            modelBuilder.Entity<SONGS>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
