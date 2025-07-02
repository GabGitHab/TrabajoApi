
using TrabajoApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoApi.DTOs;
using TrabajoApi.Modelos;
using TrabajoApi.Models.DTOs;


namespace TrabajoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Autentica _autentica;

        public UsuariosController(AppDbContext context, Autentica autentica)
        {
            _context = context;
            _autentica = autentica;
        }

        [HttpPost]
        public ActionResult<Usuario> PostUsuario([FromBody] RegistroUsuarioDTO registroUsuarioDTO)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            Usuario? usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == registroUsuarioDTO.NombreUsuario);

            if (usuario != null)
                return BadRequest("Ya existe un usuario con ese email");

            usuario = new Usuario(
                registroUsuarioDTO.NombreUsuario,
                registroUsuarioDTO.Clave
            );

            _context.Usuarios.Add(usuario);

            try
            {
                _context.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult<Usuario> PostLogin([FromBody] LoginUsuarioDTO loginUsuarioDTO)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            Usuario? usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == loginUsuarioDTO.NombreUsuario);
            string passwordEncriptadoParametro = Usuario.EncriptarPassword(loginUsuarioDTO.Clave);

            if (usuario == null || usuario.PasswordHash != passwordEncriptadoParametro)
                return Unauthorized("Usuario incorrecto o contraseña incorrecta");

            RespuestaLoginTokenDTO token = new RespuestaLoginTokenDTO();
            token.Token = _autentica.CrearToken(usuario);
            return Ok(token);
        }
    }
}