using System;
using Elite.DataCollecting.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Elite.DataCollecting.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DocumentData> DocumentData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    
    }
}
