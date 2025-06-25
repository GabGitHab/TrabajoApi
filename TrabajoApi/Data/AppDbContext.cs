using Microsoft.EntityFrameworkCore;
using TrabajoApi.Modelos;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<CategoriaArtista> CategoriaArtistas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Artista>()
            .HasOne(artista => artista.CategoriaArtista)
            .WithMany(categoriaArtista => categoriaArtista.Artistas)
            .HasForeignKey(artista => artista.CategoriaArtistaId);
    }
}


