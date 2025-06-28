namespace TrabajoApi.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Artista> Artistas { get; set; } = new List<Artista>();
    }
}


