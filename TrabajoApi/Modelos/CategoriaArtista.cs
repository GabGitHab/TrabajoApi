using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace TrabajoApi.Modelos
{
    public class CategoriaArtista
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [JsonIgnore]
        public int Artista { get; set; }
        [JsonIgnore]
        public List<Artista> Artistas { get; set; } = new();

        public CategoriaArtista() { }

        public CategoriaArtista(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
