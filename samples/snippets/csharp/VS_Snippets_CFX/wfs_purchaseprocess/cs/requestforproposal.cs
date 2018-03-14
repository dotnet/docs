//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Microsoft.Samples.WF.PurchaseProcess
{

    [Serializable]
    public class RequestForProposal
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Vendor> InvitedVendors { get; set; }
        public IDictionary<int, VendorProposal> VendorProposals { get; set; }
        public VendorProposal BestProposal { get; set; }
        public DateTime CreationDate { get; set; }        
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; }

        public RequestForProposal()
        {
            this.InvitedVendors = new List<Vendor>();
            this.VendorProposals = new Dictionary<int, VendorProposal>();
            this.CreationDate = DateTime.Now;
            this.Status = "active";
        }

        // register a proposal from a vendor within this instance
        public void RegisterProposal(Vendor vendor, double value)
        {
            VendorProposals.Add(
                vendor.Id,
                new VendorProposal
                {
                    Vendor = vendor,
                    Value = value,
                    Date = DateTime.Now
                });
        }

        // returns true if a vendor is invited to submit a proposal within this instance
        public bool IsInvited(int vendorId)
        {
            foreach (Vendor vendor in this.InvitedVendors)
            {
                if (vendor.Id.Equals(vendorId))
                    return true;
            }
            return false;
        }

        // returns true if this RfP is finished
        public bool IsFinished()
        {
            return this.Status.Equals("finished");
        }

        // returns a string with all the invited vendors.
        public string GetInvitedVendorsStatus()
        {
            return GetInvitedVendorsStatus(false);
        }        

        // returns a string with all the invited vendors. If the status flag is
        // true, it also add the status of each vendor proposal
        public string GetInvitedVendorsStatus(bool addStatus)
        {
            string ret = string.Empty;                
            foreach (Vendor vendor in this.InvitedVendors)
            {
                if (ret != string.Empty)
                    ret += ",";

                ret += vendor.Name;

                if (addStatus)
                {
                    if (this.VendorProposals.ContainsKey(vendor.Id))
                    {
                        ret += " (received)";
                    }
                    else
                    {
                        ret += " (waiting)";
                    }
                }
            }

            return ret;
        }
        
    }
}
