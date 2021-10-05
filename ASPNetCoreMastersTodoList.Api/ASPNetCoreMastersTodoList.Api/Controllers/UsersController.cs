using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreMastersTodoList.Api.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static ASPNetCoreMastersTodoList.Api.ApiModels.AuthModel;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private Authentication _auth;
        public UsersController(IOptions<Authentication> options)
        {
            _auth = options.Value;
        }

        [HttpPost("login")]
        public IActionResult Login(UserApiModel model)
        {
           /* var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
           */
            return Ok(_auth.JWT);
        }
    }
}
