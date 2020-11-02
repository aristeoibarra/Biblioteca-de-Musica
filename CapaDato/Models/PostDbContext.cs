using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CapaDato.Models
{
    public partial class PostDbContext : DbContext
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["MusicBitDB"].ToString();
        public PostDbContext()
        {
        }

        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artista> Artista { get; set; }
        public virtual DbSet<Cancion> Cancion { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql(connectionString, x => x.ServerVersion("10.1.38-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artista>(entity =>
            {
                entity.HasKey(e => e.CveArtista)
                    .HasName("PRIMARY");

                entity.ToTable("artista");

                entity.Property(e => e.CveArtista)
                    .HasColumnName("cve_artista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreArtista)
                    .HasColumnName("nombre_artista")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Cancion>(entity =>
            {
                entity.HasKey(e => e.CveCancion)
                    .HasName("PRIMARY");

                entity.ToTable("cancion");

                entity.HasIndex(e => e.CveartistaCancion)
                    .HasName("FKartista_cancion");

                entity.HasIndex(e => e.CvegeneroCancion)
                    .HasName("FKgenero_cancion");

                entity.Property(e => e.CveCancion)
                    .HasColumnName("cve_cancion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CveartistaCancion)
                    .HasColumnName("cveartista_cancion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CvegeneroCancion)
                    .HasColumnName("cvegenero_cancion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LetraCancion)
                    .HasColumnName("letra_cancion")
                    .HasColumnType("varchar(10000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NombreCancion)
                    .HasColumnName("nombre_cancion")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.CveartistaCancionNavigation)
                    .WithMany(p => p.Cancion)
                    .HasForeignKey(d => d.CveartistaCancion)
                    .HasConstraintName("FKartista_cancion");

                entity.HasOne(d => d.CvegeneroCancionNavigation)
                    .WithMany(p => p.Cancion)
                    .HasForeignKey(d => d.CvegeneroCancion)
                    .HasConstraintName("FKgenero_cancion");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.CveGenero)
                    .HasName("PRIMARY");

                entity.ToTable("genero");

                entity.Property(e => e.CveGenero)
                    .HasColumnName("cve_genero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreGenero)
                    .HasColumnName("nombre_genero")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
