using System.ComponentModel.DataAnnotations;

namespace TrabajoApi.Modelos


{
    public class Artista
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
        public string Genero { get; set; }
        [Required]
        public DateTime FechaNacimiento {  get; set; }
        [Required]
        public string Nacionalidad { get; set; }

        public CategoriaArtista CategoriaArtista { get; set; }
        public int CategoriaArtistaId { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<Espectaculo> Espectaculos { get; set; }
        

        public Artista() { }
        public Artista(string nombre, string genero, DateTime fechaNacimiento, string nacionalidad, int categoriaId)
        {
            Nombre = nombre;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Nacionalidad = nacionalidad;
            CategoriaArtistaId = categoriaId;
        }
    }

}
