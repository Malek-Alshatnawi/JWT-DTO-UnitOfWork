
using Day2.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //this is a new code
        [HttpPost]
        public ActionResult Login(UserDataRecord data)
        {
            //Validate the username and password
            if (data.username == "admin" && data.password == "123")
            {

                #region
                //DEFINE THE CLAIMS TO BE ASSIGNED TO THE TOKEN 
                List<Claim> claimsdata = new List<Claim>();
                claimsdata.Add(new Claim(ClaimTypes.Name, data.username));
                claimsdata.Add(new Claim("Phone Number", "00962797419964"));

                //DEFINE SECURITY KEY TO BE ASSIGNED TO signingCred obj
                String MyKey = "This is my secret key malek using sha256";
                var MySecurityKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(MyKey));

                //DEFINE THE signingCredentials  TO BE ASSIGNED TO THE TOKEN 
                var signingCred = new SigningCredentials(MySecurityKey, SecurityAlgorithms.HmacSha256);
                #endregion

                var token = new JwtSecurityToken
                   (
                    claims: claimsdata,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCred
                   );

                //THE ABOVE STEPTS IS TO CREATE/GENERATE THE TOKEN AS AN OBJ THE BELOW STEPS IS TO CONVERT THE TOKEN INTO STRING FORMAT TO BE SENT/RETURNED TO THE CLIENT

                var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(stringToken);
            }
            else
            {
                return BadRequest("Login Failed");
            }
        }



        [HttpGet]
        [Authorize]
        public ActionResult GetAll()
        {
            return Ok("This is a success reponse just to test");
        }




    }
}
