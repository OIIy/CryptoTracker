using CryptoTracker.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System;
using CryptoTracker.Api.Repositories.Interfaces;

namespace CryptoTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DataContext dataContext;
        private readonly IUserService userRepository;
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration, DataContext dataContext, IUserService userRepository)
        {
            this.configuration = configuration;
            this.dataContext = dataContext;
            this.userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            User user = new User();

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            try
            {
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = request.Username;

                // TODO: Save user object to the database
                dataContext.Users.Add(user);
                dataContext.SaveChanges();   
            }
            catch (Exception error)
            {
                // Write logs to DB table instead of writing to console
                return BadRequest(error);
            }

            return Ok(user.UserId);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            // Find user
            User user = userRepository.GetUserDetails(request.Username);
            
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (userRepository.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password doesn't match.");
            }

            // Create jwt token
            string token = userRepository.CreateToken(user);

            return Ok(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
