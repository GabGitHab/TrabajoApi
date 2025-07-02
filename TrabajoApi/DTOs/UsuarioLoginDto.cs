using System.ComponentModel.DataAnnotations;

namespace TrabajoApi.Models.DTOs
{
    public class LoginUsuarioDTO
    {
        [Required]
        public string NombreUsuario { get; set; } = string.Empty;
        [Required]
        public string Clave { get; set; } = string.Empty;
    }
}