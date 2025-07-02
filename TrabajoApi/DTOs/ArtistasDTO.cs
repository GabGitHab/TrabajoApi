using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TrabajoApi.Models.DTOs
{
    public class ArtistasDTO
    {
        public int Id { get; set; } = 0;
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public string? Genero { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public string? Nacionalidad { get; set; }
        [Required]
        public int CategoriaArtistaId { get; set; } = 0;
    }
}