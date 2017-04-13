using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Shared.Entities
{
    [DataContract]
    public class PartTimeEmployee : Employee
    {
        [DataMember]
        public double HourlyRate { get; set; }
    }
}
