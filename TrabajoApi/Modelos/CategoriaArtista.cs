using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
namespace TrabajoApi.Modelos
{
    public class CategoriaArtista
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int Artista { get; set; }
        public List <Artista> Artistas { get; set; }

        public CategoriaArtista() { }

        public CategoriaArtista(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
