//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Activities.Hosting;
using System.Activities.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Microsoft.Samples.WF.PurchaseProcess
{

//<Snippet2>
    class XmlPersistenceParticipant : PersistenceParticipant
    {
        const string propertiesNamespace = "urn:schemas-microsoft-com:System.Activities/4.0/properties";
        private Guid Id;

        public XmlPersistenceParticipant(Guid id)
        {
            Id = id;
        }

        //Add any additional necessary data to persist here
        protected override void CollectValues(out IDictionary<XName, object> readWriteValues, out IDictionary<XName, object> writeOnlyValues)
        {
            base.CollectValues(out readWriteValues, out writeOnlyValues);
        }

        //Implementations of MapValues are given all the values collected from all participantsâ€™ implementations of CollectValues
        protected override IDictionary<XName, object> MapValues(IDictionary<XName, object> readWriteValues, IDictionary<XName, object> writeOnlyValues)
        {
            XName statusXname = XName.Get("Status", propertiesNamespace);

            IDictionary<XName, object> mappedValues = base.MapValues(readWriteValues, writeOnlyValues);

            RequestForProposal requestForProposal = null;
            string status = string.Empty;
            object value = null;

            //retrieve the status of the workflow
            if (writeOnlyValues.TryGetValue(statusXname, out value))
            {
                status = (string)value;
            }

            //retrieve the RequestForProposal object
            foreach (KeyValuePair<System.Xml.Linq.XName, object> item in writeOnlyValues)
            {
                if (item.Value is LocationInfo)
                {
                    LocationInfo li = (LocationInfo)item.Value;
                    if (li.Value is RequestForProposal)
                    {
                        requestForProposal = (RequestForProposal)li.Value;
                    }
                }
            }

            IOHelper.EnsureAllRfpFileExists();

            // load the document
            XElement doc = XElement.Load(IOHelper.GetAllRfpsFileName());

            IEnumerable<XElement> current =
                                    from r in doc.Elements("requestForProposal")
                                    where r.Attribute("id").Value.Equals(Id.ToString())
                                    select r;

            if (status == "Closed")
            {
                // erase nodes for the current rfp                    
                foreach (XElement xe in current)
                {
                    xe.Attribute("status").Value = "finished";
                }
            }
            else
            {
                // erase nodes for the current rfp                    
                foreach (XElement xe in current)
                {
                    xe.Remove();
                }

                // get the Xml version of the Rfp, add it to the document and save it
                if (requestForProposal != null)
                {
                    XElement e = SerializeRfp(requestForProposal, Id);
                    doc.Add(e);
                }
            }

            doc.Save(IOHelper.GetAllRfpsFileName());

            return mappedValues;
        }
//</Snippet2>
        // serialize a Rfp to Xml using Linq to Xml
        XElement SerializeRfp(RequestForProposal rfp, Guid instanceId)
        {
            // main body of the rfp
            XElement ret =
               new XElement("requestForProposal",
                   new XAttribute("id", instanceId.ToString()),
                   new XAttribute("status", rfp.Status),
                       new XElement("creationDate", rfp.CreationDate),
                       new XElement("completionDate", rfp.CompletionDate),
                       new XElement("title", rfp.Title),
                       new XElement("description", rfp.Description));

            // add invited vendors
            XElement invitedVendors = new XElement("invitedVendors");
            foreach (Vendor vendor in rfp.InvitedVendors)
            {
                invitedVendors.Add(
                    new XElement("vendor",
                        new XAttribute("id", vendor.Id)));
            }
            ret.Add(invitedVendors);

            // add vendor proposals            
            XElement vendorProposals = new XElement("vendorProposals");
            foreach (VendorProposal proposal in rfp.VendorProposals.Values)
            {
                vendorProposals.Add(
                    new XElement("vendorProposal",
                        new XAttribute("vendorId", proposal.Vendor.Id),
                        new XAttribute("date", proposal.Date),
                        new XAttribute("value", proposal.Value)));
            }
            ret.Add(vendorProposals);

            // add best proposal
            if (rfp.BestProposal != null && rfp.BestProposal.Vendor != null)
            {
                ret.Add(
                    new XElement("bestProposal",
                        new XAttribute("vendorId", rfp.BestProposal.Vendor.Id),
                        new XAttribute("date", rfp.BestProposal.Date),
                        new XAttribute("value", rfp.BestProposal.Value)));
            }

            return ret;
        }

        //All of the values loaded from the InstanceData property bag are provided to implementations of PublishValues.  
        protected override void PublishValues(IDictionary<XName, object> readWriteValues)
        {
            base.PublishValues(readWriteValues);
        }
    }
}
