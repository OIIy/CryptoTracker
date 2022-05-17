﻿using CryptoTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Api
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
