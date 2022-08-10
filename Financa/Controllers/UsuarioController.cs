using Financa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Financa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpPost]
        public void AdicionaUsuario([FromBody]Usuario usuario)
        {
            usuarios.Add(usuario);
            Console.WriteLine(usuario.Name);
        }

        [HttpGet]
        public IEnumerable<Usuario> RecuperaUsuario()
        {
            return usuarios;
        }
    }
}
