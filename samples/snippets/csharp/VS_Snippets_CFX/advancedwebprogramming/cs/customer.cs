//  Copyright (c) Microsoft Corporation. All rights reserved.

using System;

using System.Runtime.Serialization;

namespace Microsoft.WebProgrammingModel.Samples
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Address;
        [DataMember]
        public string Name;

        [DataMember]
        public Uri Uri;

        public Customer(string name, string address, Uri uri)
        {
            this.Name = name;
            this.Address = address;
            this.Uri = uri;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Name, Address, Uri);
        }
    }
}
