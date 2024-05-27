using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sln_trans_harian.Models
{
    public partial class Latihan2Context : DbContext
    {
        public Latihan2Context()
        {
        }

        public Latihan2Context(DbContextOptions<Latihan2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Trans_Harian> Trans_Harians { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Latihan2;Username=postgres;Password=re123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trans_Harian>(entity =>
            {
                entity.HasKey(e => e.trans_id)
                    .HasName("Trans_Harian_pkey");

                entity.ToTable("Trans_Harian");

                entity.Property(e => e.trans_id).UseIdentityAlwaysColumn();

                entity.Property(e => e.bulan).HasMaxLength(2);

                entity.Property(e => e.jumlah).HasPrecision(18, 2);

                entity.Property(e => e.keterangan).HasMaxLength(500);

                entity.Property(e => e.tahun).HasMaxLength(4);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
