using Domain.Entities;
using System.Collections.Generic;

namespace Application
{
    public interface ISwipeService
    {
        void AddSwipesToDatabase(Terminal terminal);
    }
}
