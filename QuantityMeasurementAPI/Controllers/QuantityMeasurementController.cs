using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
namespace QuantityMeasurementAPI.Controllers
{
    [Route("/api")]
    [ApiController]
    public class QuantityMeasurementAPIController : ControllerBase
    {
        [HttpPost("compare")]
        public IActionResult Compare([FromBody] QuantityInputDTO input)
        {
            if (input.Quantity1 == null || input.Quantity2 == null || input.Quantity1.Unit == null || input.Quantity2.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }
            var service = new QuantityMeasurementService();
            var result = service.Compare(input.Quantity1, input.Quantity2);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] QuantityInputDTO input)
        {
            if (input.Quantity1 == null || input.Quantity2 == null || input.Quantity1.Unit == null || input.Quantity2.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }
            var service = new QuantityMeasurementService();
            var result = service.Add(input.Quantity1, input.Quantity2);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] QuantityInputDTO input)
        {
            if (input.Quantity1 == null || input.Quantity2 == null || input.Quantity1.Unit == null || input.Quantity2.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }
            var service = new QuantityMeasurementService();
            var result = service.Subtract(input.Quantity1, input.Quantity2);
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] QuantityInputDTO input)
        {
            if (input.Quantity1 == null || input.Quantity2 == null || input.Quantity1.Unit == null || input.Quantity2.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }
            var service = new QuantityMeasurementService();
            var result = service.Division(input.Quantity1, input.Quantity2);
            return Ok(result);
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var service = new QuantityMeasurementService();
            var history = service.GetHistory();
            return Ok(history);
        }
    }
    [Route("/api/auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            QuantityMeasurementDatabaseRepository repository = new QuantityMeasurementDatabaseRepository();
            var hasher = new PasswordHasher<UserEntity>();
            try
            {
                var user = repository.GetUserByEmail(login.Email);
                // Console.WriteLine("Username entered: [" + login.Username + "]");
                if (user == null)
                {
                    Console.WriteLine("User NOT found in DB");
                    return Unauthorized("Invalid Email");
                }

                // Console.WriteLine("User found: " + user.Username);
                // Console.WriteLine("Stored Hash: " + user.Password);
                // Console.WriteLine("Hash Length: " + user.Password.Length);

                var result = hasher.VerifyHashedPassword(user, user.Password, login.Password);

                if (result == PasswordVerificationResult.Failed)
                {
                    return Unauthorized("Invalid Password");
                }
                // Console.WriteLine("Entered Password: [" + login.Password + "]");
                // Console.WriteLine("Verification Result: " + result);
                var token = GenerateJwtToken(user);
                return Ok(new { message = "Login successful", token });
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO register)
        {
            if (string.IsNullOrEmpty(register.Username) || string.IsNullOrEmpty(register.Password) || string.IsNullOrEmpty(register.Email) || string.IsNullOrEmpty(register.Phone))
            {
                return BadRequest("Username, Password, Email and Phone are required.");
            }
            var service = new QuantityMeasurementAuthService();
            service.SaveUsers(register);
            return Ok("Registration successful");
        }

        private string GenerateJwtToken(UserEntity user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim("UserId",user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_A_SUPER_SECRET_KEY_1234567890"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "QuantityMeasurementAPI",
                audience: "QuantityMeasurementAPI",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}