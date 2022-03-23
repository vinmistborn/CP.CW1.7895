using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.DAL.Repositories
{
    /// <summary>
    /// Encapsulates and defines methods for Swipes table
    /// </summary>
    public class SwipeRepository : ISwipeRepository
    {
       /// <summary>
       /// Inserts a collection of swipes to the Swipe table
       /// </summary>
       /// <param name="swipes">Swipes that will be added to</param>
       public void BulkInsert(List<Swipe> swipes)
        { 
            using(var dbContext = new AppDbContext())
            {
                dbContext.Swipes.AddRange(swipes);
                dbContext.SaveChanges();
            }
        }

        public List<Swipe> GetSwipes()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Swipes.ToList();
            }
        }

        public void DeleteSwipes(List<Swipe> swipes)
        {
            using (var dbContext = new AppDbContext())
            {
                foreach (var swipe in swipes)
                {
                    var tempSwipe = dbContext.Swipes.Find(swipe.Id);
                    dbContext.Swipes.Remove(tempSwipe);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}