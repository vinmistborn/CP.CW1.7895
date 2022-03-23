using System;
using System.Collections.Generic;
using System.Web;
using Domain.Entities;

namespace Infrastructure.DAL.Repositories
{
    public interface ISwipeRepository
    {
        void BulkInsert(List<Swipe> swipes);
        List<Swipe> GetSwipes();
        void DeleteSwipes(List<Swipe> swipes);
    }
}