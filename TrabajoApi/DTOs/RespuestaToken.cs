using System.ComponentModel.DataAnnotations;

namespace TrabajoApi.Models.DTOs
{
    public class RespuestaLoginTokenDTO
    {
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}