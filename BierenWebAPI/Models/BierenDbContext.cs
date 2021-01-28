using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BierenWebAPI.Data
{
    public partial class BierenDbContext : DbContext
    {
        public BierenDbContext()
        {
        }

        public BierenDbContext(DbContextOptions<BierenDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bier> Bieren { get; set; }
        public virtual DbSet<Brouwer> Brouwers { get; set; }
        public virtual DbSet<Soort> Soorten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.;Database=BierenDbWEBAPI;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bier>(entity =>
            {
                entity.ToTable("Bier");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Naam)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brouwers)
                    .WithMany(p => p.Bieren)
                    .HasForeignKey(d => d.BrouwerId)
                    .HasConstraintName("FK_Bieren_Brouwers");

                entity.HasOne(d => d.Soorten)
                    .WithMany(p => p.Bieren)
                    .HasForeignKey(d => d.SoortId)
                    .HasConstraintName("FK_Bieren_Soorten");
            });

            modelBuilder.Entity<Brouwer>(entity =>
            {
                entity.ToTable("Brouwer");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Adres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrNaam)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gemeente)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Soort>(entity =>
            {
                entity.ToTable("Soort");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.SoortNaam)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
   
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
