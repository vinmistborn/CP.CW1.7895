using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.DAL.Repositories
{
    public class TerminalRepository : ITerminalRepository
    {
        public List<Terminal> GetTerminals()
        {
            using(var dbContext = new AppDbContext())
            {
                return dbContext.Terminals.ToList();
            }
        }

        public void Update(Terminal terminal)
        {
            using(var dbContext = new AppDbContext())
            {
                var existingTerminal = dbContext.Terminals.Find(terminal.IP);
                dbContext.Entry(existingTerminal).CurrentValues.SetValues(terminal);
                dbContext.SaveChanges();
            }
        }
    }
}