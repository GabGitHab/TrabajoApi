using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajoApi.Modelos;


namespace Artistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArtistasController(AppDbContext context)
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

        public ActionResult<Artista> PostArtista([FromBody] Artista artista)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CategoriaArtista? categoria = _context.CategoriaArtistas.FirstOrDefault(categoria => categoria.Id == artista.CategoriaArtistaId);

            if (categoria == null)
                return BadRequest("La categoría indicada no existe.");

            _context.Artistas.Add(artista);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetArtista), new { id = artista.Id }, artista);
        }
        [HttpPut("{id}")]
        public ActionResult<Artista> PutArtista(int id, [FromBody] Artista artista)
        {
            if (id != artista.Id)
            {
                return BadRequest("El ID de la URL no coincide con el del artista.");
            }

            Artista? artistaExiste = _context.Artistas.FirstOrDefault(artista => artista.Id == id);

            if (artistaExiste == null)
            {
                return BadRequest("No hay entidad para actualizar");
            }

            CategoriaArtista? categoriaArtista = _context.CategoriaArtistas.FirstOrDefault(categoriaArtista => categoriaArtista.Id == artista.CategoriaArtistaId);
            if (categoriaArtista == null)
            {
                return BadRequest("La categoria no existe");
            }

            artistaExiste.Nombre = artista.Nombre;
            artistaExiste.Genero = artista.Genero;
            artistaExiste.FechaNacimiento = artista.FechaNacimiento;
            artistaExiste.Nacionalidad = artista.Nacionalidad;
            artistaExiste.CategoriaArtistaId = artista.CategoriaArtistaId;

            _context.Artistas.Update(artistaExiste);
            _context.SaveChanges();

            return Ok(artistaExiste);
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteArtista(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Debe ingresar un Id");
            }

            Artista? artista = _context.Artistas.FirstOrDefault(artista => artista.Id == id);

            if (artista == null)
            {
                return NotFound("No se encontro el Artista");
            }
            _context.Artistas.Remove(artista);
            _context.SaveChanges();

            return Ok(true);
        }

    }
}