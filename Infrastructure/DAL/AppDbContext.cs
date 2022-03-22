using System.Data.Entity;
using Domain.Entities;

namespace Infrastructure.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDb7895")
        {

        }

        public DbSet<Swipe> Swipes { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
    }
}