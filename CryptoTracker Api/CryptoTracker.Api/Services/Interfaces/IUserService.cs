using CryptoTracker.Api.Models;

namespace CryptoTracker.Api.Services.Interfaces
{
    public interface IUserService
    {
        public User GetUserDetails(int id);
        public User GetUserDetails(string username);
        public void AddUser(User user);
        public User UpdateUser(int id);
        public void DeleteUser(int id);
        public string CreateToken(User user);
        public void CreatePasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
