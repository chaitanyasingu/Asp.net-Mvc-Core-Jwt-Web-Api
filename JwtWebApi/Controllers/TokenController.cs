using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public ActionResult GetToken()
        {
            string SecretKey = "This_is_our_secret_key_for_creating_SymetricKey_encryption";
            var SymeticSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var SigningCredentials = new SigningCredentials(SymeticSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var Token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "developers",
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: SigningCredentials
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(Token));
        }
    }
}