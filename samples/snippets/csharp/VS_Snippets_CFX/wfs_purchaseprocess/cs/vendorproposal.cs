//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;

namespace Microsoft.Samples.WF.PurchaseProcess
{

    [Serializable]
    public class VendorProposal
    {
        public Vendor Vendor { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public VendorProposal() 
        { 
        }

        public VendorProposal(Vendor vendor)
        {
            this.Vendor = vendor;
            this.Value = 0;
        }
    }
}
