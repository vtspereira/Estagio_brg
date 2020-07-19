using estagio_brg.Entities.Models;
using estagio_brg.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace estagio_brg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserApiController : ControllerBase
    {
        /// <summary>
        /// Logar na API
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/ApiUser/Login/
        ///     {
        ///        "Username": "estagioBrg",
        ///        "Password": "processoSeletivo",
        ///         }
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] UserApi userApi)
        {
            var user = UserApiRepository.Get(userApi.Username, userApi.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos!" });

            var token = TokenService.GenerateToken(user);

            return new
            {
                token
            };
        }   
    }
}
