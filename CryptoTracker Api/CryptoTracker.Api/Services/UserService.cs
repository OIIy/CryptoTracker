using CryptoTracker.Api.Models;
using CryptoTracker.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CryptoTracker.Api.Services
{
    public class UserService : IUserService
    {
        private DataContext dbContext;
        private readonly IConfiguration configuration;

        public UserService(DataContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public void AddUser(User user)
        {
            try
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch
            {
                // Log to DB
                throw;
            }
        }

        public User GetUserDetails(int id)
        {
            try
            {
                User? user = dbContext.Users.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                // Log to DB
                throw;
            }
        }

        public User GetUserDetails(string username)
        {
            try
            {
                User? user = dbContext.Users.Where(u => u.Username == username).FirstOrDefault();
                
                return user;
            }
            catch
            {
                // Log to DB
                throw;
            }
        }

        public User UpdateUser(int id)
        {
            try
            {
                User? user = dbContext.Users.Find(id);

                if (user != null)
                {
                    dbContext.Users.Remove(user);
                    dbContext.SaveChanges();
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                // Log to DB
                throw;
            }
        }

        public void DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Authentication:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public void CreatePasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
