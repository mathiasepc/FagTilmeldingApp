using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FagTilmeldingApp.Codes.EntityFrameworkModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FagTilmeldingApp.Codes.EntityFrameworkModel
{
    //partial betyder at den hører sammen med en anden klasse
    public partial class TECContext : DbContext
    {
        public TECContext()
        {
        }

        public TECContext(DbContextOptions<TECContext> options) : base(options)
        {
        }

        public virtual DbSet<Elever> Elevers { get; set; } = null!;
        public virtual DbSet<Fag> Fags { get; set; } = null!;
        public virtual DbSet<Klasse> Klasses { get; set; } = null!;
        public virtual DbSet<Lærer> Lærers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GV81FRQ;Initial Catalog=TEC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Elever>(entity =>
            {
                entity.ToTable("Elever");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Fag>(entity =>
            {
                entity.ToTable("Fag");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fag1)
                    .HasMaxLength(50)
                    .HasColumnName("Fag");

                entity.Property(e => e.LærerId).HasColumnName("LærerID");

                entity.HasOne(d => d.Lærer)
                    .WithMany(p => p.Fags)
                    .HasForeignKey(d => d.LærerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fag__LærerID__29221CFB");
            });

            modelBuilder.Entity<Klasse>(entity =>
            {
                entity.ToTable("Klasse");

                entity.Property(e => e.KlasseId).HasColumnName("KlasseID");

                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.FagId).HasColumnName("FagID");

                entity.HasOne(d => d.Elev)
                    .WithMany(p => p.Klasses)
                    .HasForeignKey(d => d.ElevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Klasse__ElevID__2CF2ADDF");

                entity.HasOne(d => d.Fag)
                    .WithMany(p => p.Klasses)
                    .HasForeignKey(d => d.FagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Klasse__FagID__2BFE89A6");
            });

            modelBuilder.Entity<Lærer>(entity =>
            {
                entity.ToTable("Lærer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

