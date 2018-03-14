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

        public override string ToString()
        {
            return String.Format( "Customer (Name={0}, Address={1})", Name, Address);
        }
    }
}