using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Terminal
    {
        /// <summary>
        /// Key - Entity Framework sets the property *IP* as a Primary Key of Terminal Table
        /// </summary>
        [Key]
        public string IP { get; set; }       
        public string Status { get; set; } = "Waiting";

        public ICollection<Swipe> Swipes { get; set; }
    }
}
