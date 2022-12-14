using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo.Application.Interfaces;
using Modelo.Application.ViewModels;

namespace Modelo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this.usuarioService.Get();

            return Ok(this.usuarioService.Get());
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UsuarioViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.usuarioService.Post(userViewModel));
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(string id)
        //{
        //    return Ok(this.userService.GetById(id));
        //}

        //[HttpPut]
        //public IActionResult Put(UserViewModel userViewModel)
        //{
        //    return Ok(this.userService.Put(userViewModel));
        //}

        //[HttpDelete]
        //public IActionResult Delete()
        //{
        //    var _userId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);

        //    return Ok(this.userService.Delete(_userId));
        //}

        //[HttpPost("authenticate"), AllowAnonymous]
        //public IActionResult Authenticate(UserAuthenticateRquestViewModel userViewModel)
        //{
        //    return Ok(this.userService.Authenticate(userViewModel));
        //}
    }
}

