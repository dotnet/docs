//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------


using System;
using System.Runtime.Serialization;

namespace Microsoft.Samples.ImplicitExplicitCorrelation
{
    [DataContract(Namespace=Constants.PharmacyServiceNamespace)]
    public class Customer
    {
        private string firstName;
        private string lastName;
        private Guid customerID;

        [DataMember]
        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [DataMember]
        public Guid CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
    }

    [DataContract(Namespace = Constants.PharmacyServiceNamespace)]
    public class Order
    {
        private Guid customerID;
        private Guid orderID;
        private int cost;
        private string drug;

        [DataMember]
        public Guid CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        [DataMember]
        public Guid OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        [DataMember]
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        [DataMember]
        public string Drug
        {
            get { return drug; }
            set { drug = value; }
        }
    }
}
