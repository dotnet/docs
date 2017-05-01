using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.ServiceModel.Samples
{
    [DataContract(Namespace = "http://tempuri.org/Customer")]
    public class Customer
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Address;
    }
}