using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contatos_NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Contatos_NetCore.Controllers
{
    public class TokenController : Controller
    {
        private readonly AcessoDBContext _context;

        public TokenController(AcessoDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/token/CreateToken")]
        public string CreateToken([FromBody]Acesso acesso)
        {
            var login = _context.Acesso.SingleOrDefault(x => x.Email == acesso.Email && x.Senha == acesso.Senha);

            if (login == null)
            {
                return "";
            }
            return new ObjectResult(GenerateToken(acesso.Email)).Value.ToString();

        }

        private string GenerateToken(string email)
        {
            var claims = new Claim[]
            {
                //define as claims para criação do token
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            //gera o token baseado nas claims
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("senhasupersecretaparaauth"));
            SigningCredentials signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtHeader jwtHeader = new JwtHeader(signingCredential);
            JwtPayload jwtPayload = new JwtPayload(claims);
            JwtSecurityToken token = new JwtSecurityToken(jwtHeader, jwtPayload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}