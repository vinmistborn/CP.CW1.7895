using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.DAL.Repositories
{
    public interface ITerminalRepository
    {
        List<Terminal> GetTerminals();
        void Update(Terminal terminal);
    }
}