using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajoApi.Modelos;

namespace CategoriaArtistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaArtistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaArtistasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<CategoriaArtista>> GetCategoriaArtistas()
        {
            return _context.CategoriaArtistas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriaArtista> GetCategoriaArtista(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id debe ser mayor a 0");
            }

            CategoriaArtista? categoriaArtista = _context.CategoriaArtistas.FirstOrDefault(categoriaArtista => categoriaArtista.Id == id);

            if (categoriaArtista == null)
            {
                return NotFound($"No se encontro la Categoria con el id {id}");
            }

            return Ok(categoriaArtista);

        }

        [HttpPost]
        public ActionResult<CategoriaArtista> PostCategoriaArtista([FromBody] CategoriaArtista catArtista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CategoriaArtistas.Add(catArtista);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoriaArtista), new { catArtista.Id }, catArtista);
        }

        [HttpPut("{id")]
        public ActionResult<CategoriaArtista> PutCategoriaArtistas(int id, [FromBody] CategoriaArtista catArtista)
        {
            if (id != catArtista.Id)
            {
                return BadRequest("El Id no coinside con el del modelo");
            }
            CategoriaArtista? categoriaExiste = _context.CategoriaArtistas.FirstOrDefault(categoriaArtista => categoriaArtista.Id == id);
            if (categoriaExiste == null)
            {
                return BadRequest("No existe esa categoria");
            }

            categoriaExiste.Nombre = catArtista.Nombre;
            categoriaExiste.Descripcion = catArtista.Descripcion;

            _context.CategoriaArtistas.Update(categoriaExiste);
            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCategoriaArtista(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Debe ingresar un Id");
            }

            CategoriaArtista? categoriaArtista = _context.CategoriaArtistas.FirstOrDefault(categoriaArtista => categoriaArtista.Id == id);

            if (categoriaArtista == null)
            {
                return NotFound("No se encontro la categoria");
            }
            _context.Remove(categoriaArtista);
            _context.SaveChanges();
            return Ok(true);
        }
    }
}