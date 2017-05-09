//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace Microsoft.Samples.Faults.FaultService
{
    [DataContract]
    public class PurchaseOrder
    {
        private string partname;
        private int quantity;

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
    }

    [DataContract]
    public class POFault
    {
        private string problem;
        private string solution;

        [DataMember]
        public string Problem 
        {
            get { return problem; }
            set { problem = value; }
        }

        [DataMember]
        public string Solution
        {
            get { return solution; }
            set { solution = value; }
        }

    }
}
