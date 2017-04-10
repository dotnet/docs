//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Xml.Linq;

namespace Microsoft.Samples.ImplicitExplicitCorrelation
{
    public static class Constants
    {
        public const string PharmacyServiceNamespace = "urn:PharmacyService";

        public static readonly XName PharmacyServiceContractName = XName.Get("IPharmacy", Constants.PharmacyServiceNamespace);
    }
}
