using Financa.Data;
using Financa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Financa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }
       
        [HttpPost]
        public IActionResult AdicionaUsuario([FromBody] Usuario usuario)
        {
           _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaUsuarioId), new { Id = usuario.Id }, usuario);
            
        }

        [HttpGet]
        public Enumerable<Usuario> RecuperaUsuario()
        {
            return _context.Usuarios;
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaUsuarioId(int id)
        {
           Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if(usuario != null)
            {
                return Ok(usuario);
            }
            return NotFound();
        }
    }
}
