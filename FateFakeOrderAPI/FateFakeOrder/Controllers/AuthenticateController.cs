using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FateFakeOrder.API.Interfaces;
using FateFakeOrder.Data.Models;
using FateFakeOrder.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FateFakeOrder.API.Controllers
{
    [Route("api/authenticate")]
    [Authorize]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthenticateController(ITokenService tokenService,IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Authenticate([FromBody] User user)
        {
            if(await _userService.GetByUsernamePassword(user.Username,user.Password) == null)
            {
                return Unauthorized();
            }

            string userToken = _tokenService.CreateToken(user);
            if(userToken == null)
            {
                return Unauthorized();
            }
            return Ok(userToken);
        }
    }
}