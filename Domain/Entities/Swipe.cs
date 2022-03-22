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
        /// <summary>
        /// Key - for Entity Framework to configure the property *Id* as PK of Swipe table
        /// DatabaseGeneratedOption.Identity - for Entity framework to configure the property *Id* as an identity column
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     
        public string IpAddress { get; set; }
     
        public string StudentId { get; set; }
     
        public DateTime EventTime { get; set; }
    
        public string Direction { get; set; }

        /// <summary>
        /// For Entity Framework to configure a one-to-many relationship with Swipe table
        /// </summary>
        public Terminal Terminal { get; set; }
    }
}
