using IntelviaStore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IntelviaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByEmailAsync(model.Email);
            if (userExist != null)

                return StatusCode(StatusCodes.Status500InternalServerError, new Reponse { Status = "Error", Message = "User Alredy Exist" });
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Reponse { Status = "Error", Message = "User Creation failed" });
            }
            return Ok(new Reponse { Status = "Succes", Message = "User Created Seccefuly" });


        }


        
        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (var useRrole in userRoles)
                {

                    authClaims.Add(new Claim(ClaimTypes.Role, useRrole));

                }
                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));//secrit app
                    var Token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)

                        );
                    return Ok(new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(Token)
                    });
               
               
            }
            return Unauthorized();
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByEmailAsync(model.Email);
            if (userExist != null)

                return StatusCode(StatusCodes.Status500InternalServerError, new Reponse { Status = "Error", Message = "User Alredy Exist" });
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Reponse { Status = "Error", Message = "User Creation failed" });
            }
            if (!await roleManager.RoleExistsAsync(userRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(userRoles.Admin));

            if (!await roleManager.RoleExistsAsync(userRoles.User))
                await roleManager.CreateAsync(new IdentityRole(userRoles.User));

            if(await roleManager.RoleExistsAsync(userRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, userRoles.Admin);
            }

            return Ok(new Reponse { Status = "Succes", Message = "User Created Seccefuly" });


        }
    }
}
