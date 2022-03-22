using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Domain.Entities
{
    [DataContract]
    public class Progress
    {
        [DataMember]
        public List<Terminal> UpdatedTerminals { get; set; } = new List<Terminal>();
    }
}