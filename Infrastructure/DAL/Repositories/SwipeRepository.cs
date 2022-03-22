using System.Collections.Generic;
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
    }
}