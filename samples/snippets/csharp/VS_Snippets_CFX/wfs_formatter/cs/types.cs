//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.ServiceModel;
using System.Xml.Serialization;

namespace Microsoft.Samples.WorkflowServicesSamples.EchoWorkflowClient
{
    public class Expense
    {
        public double Amount { get; set; }
        public string Notes { get; set; }
    }

    public class Travel : Expense
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Carrier { get; set; }
    }

    public class Meal : Expense
    {
        public string Vendor { get; set; }
        public string Location { get; set; }
    }

    public class PurchaseOrder
    {
        [XmlAttribute]
        public string Department { get; set; }
        public string Description { get; set; }
        public double RequestedAmount { get; set; }
    }

    [MessageContract]
    public class VendorRequest
    {
        [MessageHeader]
        public string requestingDepartment;
        [MessageBodyMember]
        public string Name;
        [MessageBodyMember]
        public string Address;
    }
    [MessageContract]
    public class VendorResponse
    {
        [MessageBodyMember]
        public bool isPreApproved;
    }

}
