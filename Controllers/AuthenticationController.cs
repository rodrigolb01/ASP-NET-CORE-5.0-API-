using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;
using WebApplication3.Domain.Services;
using WebApplication3.Extensions;
using WebApplication3.Resources;
using WebApplication3.Util;

namespace WebApplication3.Controllers
{
    [Route("/api/[Controller]")]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            this._userService = userService;
            this._mapper = mapper;
            this._configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> VerifyLogin([FromBody] AuthUserResource resource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var user = _mapper.Map<AuthUserResource, User>(resource);
                var result = await _userService.FirstOrDefaultAsync(user.Login, user.Password);

                if (result == null)
                    return BadRequest("Erro ao realizar o login. usuario nao existe");



                var token = CryptoFunctions.GenerateToken(_configuration, user);

                return Ok(new
                {
                    error = false,
                    result = new
                    {
                        token,
                        user = new { user.Id, user.Login }
                    }
                });
            }
            catch (Exception ex)
            {
                var message = "Erro ao tentar realizar o login. Excecao inesperada";
                return BadRequest(new { error = true, result = new { message } });
            }
        }
    }
}
