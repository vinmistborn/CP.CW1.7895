using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.DAL.Repositories
{
    public class SwipeRepository : ISwipeRepository
    {
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