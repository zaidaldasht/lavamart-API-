using lavamart.Data.models;
using lavamart.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lavamart.Controllers
{
    [Route("lavamart/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Users> _UserManager;
        private readonly SignInManager<Users> _SignInManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly IConfiguration _configuration;


        public AccountController(UserManager<Users> UserManager, SignInManager<Users> SignInManager, RoleManager<IdentityRole> RoleManager, IConfiguration configuration)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _RoleManager = RoleManager;
            _configuration = configuration;

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> signUp(dtoUsers user)
        {
            //Debug
            Console.WriteLine($"UserName: '{user.UserName}'");
            Console.WriteLine($"Email: '{user.Email}'");
            Console.WriteLine($"PhoneNumber: '{user.PhoneNumber}'");
            Console.WriteLine($"PasswordHash: '{user.Password}'");

            if (ModelState.IsValid)
            {
                Users appUser = new()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,

                };
                IdentityResult result = await _UserManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    return Ok("Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> signIn(dtosignIn signIn)
        {
            if (ModelState.IsValid)
            {
                Users? user = await _UserManager.FindByNameAsync(signIn.UserName);
                if (user != null)
                {
                    if (await _UserManager.CheckPasswordAsync(user, signIn.Password))
                    {
                        var claims = new List<Claim>();
                        //claims.Add(new Claim("name", "value"));
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _UserManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }
                        //signingCredentials
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: _configuration["JWT:Issuer"],
                            audience: _configuration["JWT:Audience"],
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: sc
                            );
                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };
                        return Ok(_token);

                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Name is invalid");
                }
            }
            return BadRequest(ModelState);
        }



    }
}
