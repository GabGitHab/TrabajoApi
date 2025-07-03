using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajoApi.Modelos;
using TrabajoApi.DTOs;

namespace TrabajoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspectaculosController : Controller
    {
        private readonly AppDbContext _context;

        public EspectaculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Artista>> GetArtistas()
        {
            return _context.Artistas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Artista> GetArtista(int id)
        {
            if (id <= 0)
                return BadRequest("Id debe ser mayor a cero");

            Artista? artista = _context.Artistas.FirstOrDefault(artista => artista.Id == id);

            if (artista == null)
                return NotFound($"Artista con Id ({id}) no fue encontrado");

            return Ok(artista);
        }
        [HttpPost]
        public ActionResult<Espectaculo> PostEspectaculo([FromBody] EspectaculoDTO espectaculoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validar que el artista existe
            var artistaExiste = _context.Artistas.Any(a => a.Id == espectaculoDto.ArtistaId);
            if (!artistaExiste)
                return BadRequest("El artista indicado no existe.");

            // Mapear el DTO a la entidad
            var espectaculo = new Espectaculo
            {
                Nombre = espectaculoDto.Nombre,
                Fecha = espectaculoDto.Fecha,
                Hora = espectaculoDto.Hora,
                ArtistaId = espectaculoDto.ArtistaId
            };

            _context.Espectaculos.Add(espectaculo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEspectaculo), new { id = espectaculo.Id }, espectaculo);
        }
        [HttpPut("{id}")]
        public ActionResult<Espectaculo> PutEspectaculo(int id, [FromBody] EspectaculoDTO espectaculoDto)
        {
            if (id <= 0)
                return BadRequest("Id debe ser mayor a cero");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var espectaculo = _context.Espectaculos.FirstOrDefault(e => e.Id == id);
            if (espectaculo == null)
                return NotFound($"Espectáculo con Id {id} no fue encontrado");

            // Validar que el artista existe
            var artistaExiste = _context.Artistas.Any(a => a.Id == espectaculoDto.ArtistaId);
            if (!artistaExiste)
                return BadRequest("El artista indicado no existe.");

            // Actualizar los campos del espectáculo
            espectaculo.Nombre = espectaculoDto.Nombre;
            espectaculo.Fecha = espectaculoDto.Fecha;
            espectaculo.Hora = espectaculoDto.Hora;
            espectaculo.ArtistaId = espectaculoDto.ArtistaId;

            _context.Espectaculos.Update(espectaculo);
            _context.SaveChanges();

            return Ok(espectaculo);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteEspectaculo(int id)
        {
            if (id <= 0)
                return BadRequest("Id debe ser mayor a cero");

            var espectaculo = _context.Espectaculos.FirstOrDefault(e => e.Id == id);
            if (espectaculo == null)
                return NotFound($"Espectáculo con Id ({id}) no fue encontrado");

            _context.Espectaculos.Remove(espectaculo);
            _context.SaveChanges();

            return NoContent();
        }

        private object GetEspectaculo()
        {
            throw new NotImplementedException();
        }
    }
}
