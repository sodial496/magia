using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRest_T.Data;
using ApiRest_T.Models;

namespace ApiRest_T.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApiRest_TContext _context;

        public UsuariosController(ApiRest_TContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.id)
            {
                return BadRequest();
            }

            if(usuario.casa.Equals("Gryffindor") || usuario.casa.Equals("gryffindor") || usuario.casa.Equals("GRYFFINDOR") ||
                usuario.casa.Equals("Hufflepuff") || usuario.casa.Equals("hufflepuff") || usuario.casa.Equals("HUFFLEPUFF") ||
                usuario.casa.Equals("Ravenclaw") || usuario.casa.Equals("ravenclaw") || usuario.casa.Equals("RAVENCLAW") ||
                usuario.casa.Equals("Slytherin") || usuario.casa.Equals("slytherin") || usuario.casa.Equals("SLYTHERIN"))
            {
                _context.Entry(usuario).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
            
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            
                _context.Usuario.Add(usuario);
            ///string casa = usuario.casa;
            if (usuario.casa.Equals("Gryffindor") || usuario.casa.Equals("gryffindor") || usuario.casa.Equals("GRYFFINDOR") ||
                usuario.casa.Equals("Hufflepuff") || usuario.casa.Equals("hufflepuff") || usuario.casa.Equals("HUFFLEPUFF") ||
                usuario.casa.Equals("Ravenclaw") || usuario.casa.Equals("ravenclaw") || usuario.casa.Equals("RAVENCLAW") ||
                usuario.casa.Equals("Slytherin") || usuario.casa.Equals("slytherin") || usuario.casa.Equals("SLYTHERIN"))
            {
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUsuario", new { id = usuario.id }, usuario);
                
            }
            else 
            {
                
                return BadRequest();
            }

            
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.id == id);
        }
    }
}
