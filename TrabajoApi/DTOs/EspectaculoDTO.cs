namespace TrabajoApi.DTOs
{
    public class EspectaculoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }

        public string ArtistaNombre { get; set; }
        public int ArtistaId { get; set; }
    }
}
