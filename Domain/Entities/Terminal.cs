using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Terminal
    {
        [Key]
        public string IP { get; set; }       
        public string Status { get; set; } = "Waiting";

        public ICollection<Swipe> Swipes { get; set; }
    }
}
