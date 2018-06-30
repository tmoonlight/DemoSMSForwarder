using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SMSServer.Controllers
{
    [Route("api/sms")]
    public class ValuesController : Controller
    {

        private static SymmetricSecurityKey securityKey = null;

        private static SymmetricSecurityKey SecurityKey
        {
            get
            {
                if (securityKey == null)
                {
                    securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Consts.SecurityKey));
                }
                return securityKey;
            }
        }
        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet]
        [Route("GenToken")]
        public JsonResult GenToken(string userCode,string dId)
        {
            return new JsonResult(GenerateToken(userCode,dId));
        }


        /// <summary>
        /// 通过用户信息生成token
        /// </summary>
        /// <param name="userCode">用户编号</param>
        /// <param name="dId">设备Id</param>
        /// <returns></returns>
        private string GenerateToken(string userCode,string dId)
        {
            var claims = new Claim[] {
                            new Claim(ClaimTypes.NameIdentifier, userCode),
                            //new Claim(ClaimTypes.Name, userCode),
                            new Claim(ClaimTypes.Hash,dId)
                        };
            var token = new JwtSecurityToken(
            issuer: Consts.TokenIssuer,
            audience: Consts.TokenAudience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(28),
            signingCredentials: new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }
    }
}
