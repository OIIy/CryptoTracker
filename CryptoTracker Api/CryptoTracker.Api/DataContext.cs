using CryptoTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Api
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BNC2Code> BNC2Codes { get; set; }

    }
}
