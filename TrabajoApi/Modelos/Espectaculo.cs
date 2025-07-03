namespace TrabajoApi.Modelos
{
    public class Espectaculo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        
        public Artista Artista { get; set; }
        public int ArtistaId { get; set; }
    }
}
