using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class HRDB123Context : DbContext
    {
        public HRDB123Context()
        {
        }

        public HRDB123Context(DbContextOptions<HRDB123Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Aftesi> Aftesis { get; set; } = null!;
        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        public virtual DbSet<Certifikate> Certifikates { get; set; } = null!;
        public virtual DbSet<DetajeUser> DetajeUsers { get; set; } = null!;
        public virtual DbSet<DokumentaDetajeUser> DokumentaDetajeUsers { get; set; } = null!;
        public virtual DbSet<Edukim> Edukims { get; set; } = null!;
        public virtual DbSet<Leje> Lejes { get; set; } = null!;
        public virtual DbSet<PervojePune> PervojePunes { get; set; } = null!;
        public virtual DbSet<Projekt> Projekts { get; set; } = null!;
        public virtual DbSet<PushimetZyrtare> PushimetZyrtares { get; set; } = null!;
        public virtual DbSet<Roli> Rolis { get; set; } = null!;
        public virtual DbSet<UserAftesi> UserAftesis { get; set; } = null!;
        public virtual DbSet<UserCertifikate> UserCertifikates { get; set; } = null!;
        public virtual DbSet<UserEdukim> UserEdukims { get; set; } = null!;
        public virtual DbSet<UserPervojePune> UserPervojePunes { get; set; } = null!;
        public virtual DbSet<UserProjekt> UserProjekts { get; set; } = null!;
        public virtual DbSet<UserRoli> UserRolis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HRDB123.mssql.somee.com;Initial Catalog=HRDB123;Persist Security Info=False;User Id=B1234_SQLLogin_1;password=zbzz7x5mq7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aftesi>(entity =>
            {
                entity.ToTable("Aftesi");

                entity.Property(e => e.AftesiId)
                    .HasColumnName("aftesiID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.LlojiAftesise)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("llojiAftesise");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__appUser__CB9A1CDFAAD1F9FC");

                entity.ToTable("appUser");

                entity.HasIndex(e => e.UserFirstname, "UQ__appUser__4D09B61BB99F41F3")
                    .IsUnique();

                entity.HasIndex(e => e.UserLastname, "UQ__appUser__66B6E6128AD7EBFF")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__appUser__66DCF95C19BF20E2")
                    .IsUnique();

                entity.HasIndex(e => e.UserEmail, "UQ__appUser__D54ADF55B142740F")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BalancaLeje).HasColumnName("balancaLeje");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserFirstname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userFirstname");

                entity.Property(e => e.UserIsActive).HasColumnName("userIsActive");

                entity.Property(e => e.UserLastname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userLastname");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Certifikate>(entity =>
            {
                entity.HasKey(e => e.CertId)
                    .HasName("PK__Certifik__D2C93619B3EBE385");

                entity.ToTable("Certifikate");

                entity.Property(e => e.CertId)
                    .HasColumnName("certID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CertEmri)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("certEmri");

                entity.Property(e => e.CertPershkrim)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("certPershkrim");
            });

            modelBuilder.Entity<DetajeUser>(entity =>
            {
                entity.HasKey(e => e.Duid)
                    .HasName("PK__DetajeUs__2A5FEA6A710B3E06");

                entity.ToTable("DetajeUser");

                entity.Property(e => e.Duid)
                    .HasColumnName("DUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.ArsyeLargim)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("arsyeLargim");

                entity.Property(e => e.DataFillim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataFillim");

                entity.Property(e => e.DataLargim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataLargim");

                entity.Property(e => e.FotoProfili).HasColumnName("fotoProfili");

                entity.Property(e => e.GrupiPunes).HasColumnName("grupiPunes");

                entity.Property(e => e.KarteIdentiteti).HasColumnName("karteIdentiteti");

                entity.Property(e => e.NumerTelefoni)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numerTelefoni");

                entity.Property(e => e.PershkrimiVetes)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("pershkrimiVetes");

                entity.Property(e => e.PunaCaktuarNeGrup)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("punaCaktuarNeGrup");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DetajeUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetajeUse__userI__4F7CD00D");
            });

            modelBuilder.Entity<DokumentaDetajeUser>(entity =>
            {
                entity.HasKey(e => e.DokumentId)
                    .HasName("PK__Dokument__5B754AA728FB0E3A");

                entity.ToTable("Dokumenta_DetajeUser");

                entity.Property(e => e.DokumentId)
                    .HasColumnName("dokumentId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Dokument).HasColumnName("dokument");

                entity.Property(e => e.Duid).HasColumnName("DUID");

                entity.HasOne(d => d.Du)
                    .WithMany(p => p.DokumentaDetajeUsers)
                    .HasForeignKey(d => d.Duid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dokumenta___DUID__5070F446");
            });

            modelBuilder.Entity<Edukim>(entity =>
            {
                entity.HasKey(e => e.EduId)
                    .HasName("PK__Edukim__84C108B2A04F0C78");

                entity.ToTable("Edukim");

                entity.Property(e => e.EduId)
                    .HasColumnName("eduID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EduName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("eduName");
            });

            modelBuilder.Entity<Leje>(entity =>
            {
                entity.ToTable("Leje");

                entity.Property(e => e.LejeId)
                    .HasColumnName("lejeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Aprovuar).HasColumnName("aprovuar");

                entity.Property(e => e.DataFillim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataFillim");

                entity.Property(e => e.DataMbarim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataMbarim");

                entity.Property(e => e.TipiLeje)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipiLeje");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Lejes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leje__userID__5165187F");
            });

            modelBuilder.Entity<PervojePune>(entity =>
            {
                entity.HasKey(e => e.Ppid)
                    .HasName("PK__PervojeP__5FD889CD9AAFC7C7");

                entity.ToTable("PervojePune");

                entity.Property(e => e.Ppid)
                    .HasColumnName("PPID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ppemri)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PPEmri");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.ToTable("Projekt");

                entity.Property(e => e.ProjektId)
                    .HasColumnName("projektID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmriProjekt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("emriProjekt");

                entity.Property(e => e.PershkrimProjekt)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("pershkrimProjekt");
            });

            modelBuilder.Entity<PushimetZyrtare>(entity =>
            {
                entity.HasKey(e => e.PushimId)
                    .HasName("PK__Pushimet__2ABEFD9A71FBC785");

                entity.ToTable("PushimetZyrtare");

                entity.Property(e => e.PushimId)
                    .ValueGeneratedNever()
                    .HasColumnName("pushimId");

                entity.Property(e => e.Dita)
                    .HasColumnType("datetime")
                    .HasColumnName("dita");

                entity.Property(e => e.PershkrimiDita)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pershkrimiDita");
            });

            modelBuilder.Entity<Roli>(entity =>
            {
                entity.ToTable("Roli");

                entity.Property(e => e.RoliId)
                    .HasColumnName("roliID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RoliEmri)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("roliEmri");

                entity.Property(e => e.RoliPershkrim)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("roliPershkrim");
            });

            modelBuilder.Entity<UserAftesi>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AftesiId })
                    .HasName("PK__user_Aft__1FF18DB395F0E262");

                entity.ToTable("user_Aftesi");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.AftesiId).HasColumnName("aftesiID");

                entity.Property(e => e.DataPerfitimit)
                    .HasColumnType("datetime")
                    .HasColumnName("dataPerfitimit");

                entity.HasOne(d => d.Aftesi)
                    .WithMany(p => p.UserAftesis)
                    .HasForeignKey(d => d.AftesiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Afte__aftes__52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAftesis)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Afte__userI__534D60F1");
            });

            modelBuilder.Entity<UserCertifikate>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CertId })
                    .HasName("PK__user_Cer__46B68FBE826D77CC");

                entity.ToTable("user_Certifikate");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.CertId).HasColumnName("certID");

                entity.Property(e => e.DataFituar)
                    .HasColumnType("datetime")
                    .HasColumnName("dataFituar");

                entity.Property(e => e.DataSkadence)
                    .HasColumnType("datetime")
                    .HasColumnName("dataSkadence");

                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.UserCertifikates)
                    .HasForeignKey(d => d.CertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Cert__certI__5441852A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCertifikates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Cert__userI__5535A963");
            });

            modelBuilder.Entity<UserEdukim>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EduId })
                    .HasName("PK__user_Edu__F3D60C544660D68F");

                entity.ToTable("user_Edukim");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.EduId).HasColumnName("eduID");

                entity.Property(e => e.DataFillim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataFillim");

                entity.Property(e => e.DataMbarim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataMbarim");

                entity.Property(e => e.LlojiMaster)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("llojiMaster");

                entity.Property(e => e.Mesatarja).HasColumnName("mesatarja");

                entity.HasOne(d => d.Edu)
                    .WithMany(p => p.UserEdukims)
                    .HasForeignKey(d => d.EduId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Eduk__eduID__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEdukims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Eduk__userI__571DF1D5");
            });

            modelBuilder.Entity<UserPervojePune>(entity =>
            {
                entity.HasKey(e => new { e.Ppid, e.UserId })
                    .HasName("PK__user_Per__B3612800A8D86658");

                entity.ToTable("user_PervojePune");

                entity.Property(e => e.Ppid).HasColumnName("PPID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.DataFillim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataFillim");

                entity.Property(e => e.DataMbarim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataMbarim");

                entity.Property(e => e.Konfidencialiteti)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("konfidencialiteti");

                entity.Property(e => e.PershkrimiPunes)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("pershkrimiPunes");

                entity.Property(e => e.Pppozicion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PPPozicion");

                entity.HasOne(d => d.Pp)
                    .WithMany(p => p.UserPervojePunes)
                    .HasForeignKey(d => d.Ppid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Pervo__PPID__59063A47");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPervojePunes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Perv__userI__5812160E");
            });

            modelBuilder.Entity<UserProjekt>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjektId })
                    .HasName("PK__user_Pro__8CEF50C8BDA353C0");

                entity.ToTable("user_Projekt");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.ProjektId).HasColumnName("projektID");

                entity.Property(e => e.DataFillim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataFillim");

                entity.Property(e => e.DataMbarim)
                    .HasColumnType("datetime")
                    .HasColumnName("dataMbarim");

                entity.HasOne(d => d.Projekt)
                    .WithMany(p => p.UserProjekts)
                    .HasForeignKey(d => d.ProjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Proj__proje__59FA5E80");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProjekts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Proj__userI__5AEE82B9");
            });

            modelBuilder.Entity<UserRoli>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoliId })
                    .HasName("PK__user_Rol__0435B99AB8B263BA");

                entity.ToTable("user_Roli");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.RoliId).HasColumnName("roliID");

                entity.Property(e => e.DataCaktimit)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCaktimit");

                entity.HasOne(d => d.Roli)
                    .WithMany(p => p.UserRolis)
                    .HasForeignKey(d => d.RoliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Roli__roliI__5BE2A6F2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRolis)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Roli__userI__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
