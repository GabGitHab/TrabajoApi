using Microsoft.EntityFrameworkCore;
using TrabajoApi.Modelos;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<CategoriaArtista> CategoriaArtistas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Espectaculo> Espectaculos { get; set; } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Artista>()
            .HasOne(artista => artista.CategoriaArtista)
            .WithMany(categoriaArtista => categoriaArtista.Artistas)
            .HasForeignKey(artista => artista.CategoriaArtistaId);

        modelBuilder.Entity<Usuario>()
            .HasMany(usuario => usuario.Artistas)
            .WithOne(artista => artista.Usuario)
            .HasForeignKey(artista => artista.UsuarioId);

        modelBuilder.Entity<Espectaculo>()
            .HasOne(espectaculo => espectaculo.Artista)
            .WithMany(artista => artista.Espectaculos)
            .HasForeignKey(espectaculo => espectaculo.ArtistaId);
    }
}
