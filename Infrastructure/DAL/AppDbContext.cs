using System.Data.Entity;
using Domain.Entities;

namespace Infrastructure.DAL
{
    /// <summary>
    /// A class which EF implements to create and maintain the database *AppDb7895*
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDb7895")
        {
            
        }

        /// <summary>
        /// Represents the Swipes Table in DB
        /// </summary>
        public DbSet<Swipe> Swipes { get; set; }
        /// <summary>
        /// Represents the Terminals Table in DB
        /// </summary>
        public DbSet<Terminal> Terminals { get; set; }
    }
}