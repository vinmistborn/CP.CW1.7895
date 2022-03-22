using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.DAL.Repositories
{
    /// <summary>
    /// Encapsulates and defines methods for Terminal table
    /// </summary>
    public class TerminalRepository : ITerminalRepository
    {
        /// <summary>
        /// Gets the list of terminals from the Terminals table
        /// </summary>
        /// <returns>List of terminals</returns>
        public List<Terminal> GetTerminals()
        {
            using(var dbContext = new AppDbContext())
            {
                return dbContext.Terminals.ToList();
            }
        }

        /// <summary>
        /// Updates a given terminal in the database
        /// </summary>
        /// <param name="terminal">a terminal that will be updated</param>
        public void Update(Terminal terminal)
        {
            using(var dbContext = new AppDbContext())
            {
                //finding the terminal in the database
                var existingTerminal = dbContext.Terminals.Find(terminal.IP);
                //setting changed values of terminal
                dbContext.Entry(existingTerminal).CurrentValues.SetValues(terminal);
                //saving it to the database
                dbContext.SaveChanges();
            }
        }
    }
}