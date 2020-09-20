using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UsuarioService UsuarioService { get; set; }
        public UsuariosController(UsuarioService usuarioService)
        {
            this.UsuarioService = usuarioService;
        }
        public IActionResult Token([FromBody]LoginRequest loginRequest)
        {
            var token = this.UsuarioService.Login(loginRequest.Login, loginRequest.Password);

            if (String.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Login ou senha invalidos");
            }
            return Ok(new
            {
                Token = token
            });
        }
    }

    public class LoginRequest
    {
        public String Login { get; set; }

        public String Password { get; set; }

    }
}
