using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sln_kebutuhan.Models
{
    public partial class LatihanContext : DbContext
    {
        public LatihanContext()
        {
        }

        public LatihanContext(DbContextOptions<LatihanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kebutuhan> Kebutuhans { get; set; } = null!;
        public virtual DbSet<Kebutuhan_Detail> Kebutuhan_Details { get; set; } = null!;
        public virtual DbSet<List_Kebutuhan_Detail> List_Kebutuhan_Details { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\mssqlserver2019;Initial Catalog=Latihan;Persist Security Info=False;Integrated Security=SSPI;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kebutuhan>(entity =>
            {
                entity.HasKey(e => e.keb_id);

                entity.ToTable("Kebutuhan");

                entity.Property(e => e.keb_nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.keterangan)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kebutuhan_Detail>(entity =>
            {
                entity.HasKey(e => e.keb_det_id);

                entity.ToTable("Kebutuhan_Detail");

                entity.Property(e => e.keb_det_nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.status)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<List_Kebutuhan_Detail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("List_Kebutuhan_Detail");

                entity.Property(e => e.keb_det_nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.keb_nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.keterangan)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.status)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
