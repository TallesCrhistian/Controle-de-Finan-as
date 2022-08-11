using AutoMapper;
using Financa.Data;
using Financa.Data.Dtos;
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
        private IMapper _mapper;
        
        public UsuarioController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        [HttpPost]
        public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

           _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaUsuarioId), new { Id = usuario.Id }, usuario);
            
        }

        [HttpGet]
        public IEnumerable<Usuario> RecuperaUsuario()
        {
            return _context.Usuarios;
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaUsuarioId(int id)
        {
           Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario != null)
            {
                ReadUsuarioDto usuariodto = _mapper.Map<ReadUsuarioDto>(usuario);

                return Ok(usuariodto);
            }
            
            return NotFound();
        }
        [HttpPut("{id}") ]
        public IActionResult AtualizarUsuario(int id, UpdateUsuarioDto usuarioDto)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if(usuario == null)
            {
                return NotFound();
            }
            _mapper.Map(usuarioDto, usuario);

            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario (int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }
            _context.Remove(usuario);
            _context.SaveChanges();
            return NoContent();


        }
    }
}
