using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Swipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     
        public string IpAddress { get; set; }
     
        public string StudentId { get; set; }
     
        public DateTime EventTime { get; set; }
    
        public string Direction { get; set; }

        public Terminal Terminal { get; set; }
    }
}
