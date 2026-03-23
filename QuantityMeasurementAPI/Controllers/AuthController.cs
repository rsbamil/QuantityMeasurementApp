using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Models;
using Microsoft.AspNetCore.Identity;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Interface;
namespace QuantityMeasurementAPI.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IQuantityMeasurementRepository repository;
        public AuthController(IAuthService authService, IQuantityMeasurementRepository repository)
        {
            this.authService = authService;
            this.repository = repository;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            var isValidUser = authService.VerifyUser(login);
            if (isValidUser == null)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok(new { message = "Login successful", isValidUser });
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO register)
        {
            if (string.IsNullOrEmpty(register.Username) || string.IsNullOrEmpty(register.Password) || string.IsNullOrEmpty(register.Email) || string.IsNullOrEmpty(register.Phone))
            {
                return BadRequest("Username, Password, Email and Phone are required.");
            }
            authService.SaveUsers(register);
            return Ok("Registration successful");
        }
    }
}