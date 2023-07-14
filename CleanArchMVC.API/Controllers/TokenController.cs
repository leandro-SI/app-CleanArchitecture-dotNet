using CleanArchMVC.API.Models;
using CleanArchMVC.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate;
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> CreateUser([FromBody] RegisterModel userInfo)
        {
            var result = await _authenticate.RegisterUser(userInfo.Email, userInfo.Password);

            if (result)
            {
                return Ok($"Usuário {userInfo.Email} criado com sucesso!");
            }

            ModelState.AddModelError(string.Empty, "Login inválido.");
            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
            {
                return Ok(GenerateToken(userInfo));
                //return Ok($"User {userInfo.Email} Logado com sucesso!");
            }

            ModelState.AddModelError(string.Empty, "Login inválido.");
            return BadRequest(ModelState);
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            //declaração do usuário
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("meuvalor", "qualquer valor"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //gerar chave privada para assinar o token
            var privatekey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //gerar a assinatura digital do token
            var credentials = new SigningCredentials(privatekey, SecurityAlgorithms.HmacSha256);

            //definir tempo de expiração do token
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _configuration["Jwt:Issuer"],
                //audiencia
                audience: _configuration["Jwt:Audience"],
                //claims
                claims: claims,
                //data de expiracao
                expires: expiration,
                //assinatura digital
                signingCredentials: credentials
            );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracao = expiration
            };
        }

    }
}
