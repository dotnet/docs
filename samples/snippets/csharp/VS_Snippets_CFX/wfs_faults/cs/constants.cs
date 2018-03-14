//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Xml.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Samples.Faults.FaultService
{
    public static class Constants
    {
        public const string ServiceAddress = "http://localhost:8080/Service";
        public static readonly Binding Binding = new BasicHttpBinding();
        public static readonly XName POContractName = XName.Get("IPurchaseOrder", "http://Microsoft.ServiceModel.Samples");
        public const string SubmitPOName = "SubmitPO";        
    }
}
