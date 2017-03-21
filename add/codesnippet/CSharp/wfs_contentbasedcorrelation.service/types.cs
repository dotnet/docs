//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.Samples.ContentBasedCorrelation.SharedTypes
{
    
    public class PurchaseOrder
    {
        private int id;
        private string partname;
        private int quantity;
        private int customerid;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string PartName
        {
            get { return partname; }
            set { partname = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public int CustomerId
        {
            get { return customerid; }
            set { customerid = value; }
        }              
    }

    [DataContract(Name="Customer", Namespace = Constants.DefaultNamespace)]
    public class Customer
    {
        private int id;
        private string name;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
