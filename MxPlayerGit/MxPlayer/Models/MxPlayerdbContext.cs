using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MxPlayer.Models
{
    public partial class MxPlayerdbContext : DbContext
    {
        public MxPlayerdbContext()
        {
        }

        public MxPlayerdbContext(DbContextOptions<MxPlayerdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddPlay> AddPlay { get; set; }
        public virtual DbSet<SongsTable> SongsTable { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FU798E3\\SQLEXPRESS;Initial Catalog=MxPlayerdb;User ID=sa;Password=Test_1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddPlay>(entity =>
            {
                entity.HasKey(e => e.PlayId)
                    .HasName("PK__AddPlay__7CA45EA470C91A1E");

                entity.Property(e => e.PlaySongs)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.AddPlay)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__AddPlay__Id__4F7CD00D");
            });

            modelBuilder.Entity<SongsTable>(entity =>
            {
                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
