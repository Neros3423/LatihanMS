using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sln_rencana_bulanan.Models
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

        public virtual DbSet<Alokasi_Penghasilan> Alokasi_Penghasilans { get; set; } = null!;
        public virtual DbSet<Kebutuhan> Kebutuhans { get; set; } = null!;
        public virtual DbSet<Kebutuhan_Detail> Kebutuhan_Details { get; set; } = null!;
        public virtual DbSet<List_Pem_Alokasi> List_Pem_Alokasis { get; set; } = null!;
        public virtual DbSet<Pemasukkan> Pemasukkans { get; set; } = null!;
        public virtual DbSet<Rencana_Bulanan> Rencana_Bulanans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Latihan;Username=postgres;Password=re123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alokasi_Penghasilan>(entity =>
            {
                entity.HasKey(e => e.peng_id)
                    .HasName("Pengeluaran_pkey");

                entity.ToTable("Alokasi_Penghasilan");

                entity.Property(e => e.peng_id).UseIdentityAlwaysColumn();

                entity.Property(e => e.keterangan).HasMaxLength(250);

                entity.Property(e => e.peng_nama).HasMaxLength(50);
            });

            modelBuilder.Entity<Kebutuhan>(entity =>
            {
                entity.HasKey(e => e.keb_id)
                    .HasName("Kebutuhan_pkey");

                entity.ToTable("Kebutuhan");

                entity.Property(e => e.keb_id).UseIdentityAlwaysColumn();

                entity.Property(e => e.keb_nama).HasMaxLength(50);

                entity.Property(e => e.keterangan).HasMaxLength(250);
            });

            modelBuilder.Entity<Kebutuhan_Detail>(entity =>
            {
                entity.HasKey(e => e.keb_det_id)
                    .HasName("Kebutuhan_Detail_pkey");

                entity.ToTable("Kebutuhan_Detail");

                entity.Property(e => e.keb_det_id).UseIdentityAlwaysColumn();

                entity.Property(e => e.keb_det_nama).HasMaxLength(100);

                entity.Property(e => e.status).HasMaxLength(50);
            });

            modelBuilder.Entity<List_Pem_Alokasi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("List_Pem_Alokasi");

                entity.Property(e => e.bulan).HasMaxLength(2);

                entity.Property(e => e.jumlah).HasPrecision(18, 2);

                entity.Property(e => e.keterangan).HasMaxLength(250);

                entity.Property(e => e.pem_ket).HasMaxLength(250);

                entity.Property(e => e.pem_nama).HasMaxLength(50);

                entity.Property(e => e.peng_nama).HasMaxLength(50);

                entity.Property(e => e.tahun).HasMaxLength(4);
            });

            modelBuilder.Entity<Pemasukkan>(entity =>
            {
                entity.HasKey(e => e.pem_id)
                    .HasName("Pemasukkan_pkey");

                entity.ToTable("Pemasukkan");

                entity.Property(e => e.pem_id).UseIdentityAlwaysColumn();

                entity.Property(e => e.bulan).HasMaxLength(2);

                entity.Property(e => e.jumlah).HasPrecision(18, 2);

                entity.Property(e => e.keterangan).HasMaxLength(250);

                entity.Property(e => e.pem_nama).HasMaxLength(50);

                entity.Property(e => e.tahun).HasMaxLength(4);
            });

            modelBuilder.Entity<Rencana_Bulanan>(entity =>
            {
                entity.HasKey(e => e.ren_bul_id)
                    .HasName("Rencana_Bulanan_pkey");

                entity.ToTable("Rencana_Bulanan");

                entity.Property(e => e.ren_bul_id).UseIdentityAlwaysColumn();

                entity.Property(e => e.bulan).HasMaxLength(2);

                entity.Property(e => e.pemasukan).HasPrecision(18, 2);

                entity.Property(e => e.rup_peng).HasPrecision(18, 2);

                entity.Property(e => e.rup_tab).HasPrecision(18, 2);

                entity.Property(e => e.rup_takterduga).HasPrecision(18, 2);

                entity.Property(e => e.tahun).HasMaxLength(4);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
