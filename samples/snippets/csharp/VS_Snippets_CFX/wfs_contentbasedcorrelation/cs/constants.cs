//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml.Linq;

namespace Microsoft.Samples.ContentBasedCorrelation.SharedTypes
{
    public static class Constants
    {
        public const string ServiceAddress = "http://localhost:8080/Service";
        public static readonly Binding Binding = new BasicHttpBinding();
        public const string DefaultNamespace = "http://Microsoft.ServiceModel.Samples";
        public static readonly XName POContractName = XName.Get("IPurchaseOrder", DefaultNamespace);
        public const string SubmitPOName = "SubmitPO";
        public const string UpdatePOName = "UpdatePO";
        public const string AddCustomerInfoName = "AddCustomerInfo";
        public const string UpdateCustomerName = "UpdateCustomer";

        static XPathMessageContext xPathMessageContext;
        public static XPathMessageContext XPathMessageContext
        {
            get
            {
                if (xPathMessageContext == null)
                {
                    xPathMessageContext = new XPathMessageContext();
                    XPathMessageContext.AddNamespace("defns", DefaultNamespace);
                }
                return xPathMessageContext;
            }
        }
    }
}
