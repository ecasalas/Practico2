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
    public class FullTimeEmployee : Employee
    {
        [DataMember]
        public int Salary { get; set; }
    }
}
