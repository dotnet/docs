//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;

namespace Microsoft.Samples.WF.PurchaseProcess
{

    [Serializable]
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Reliablity { get; set; }        

        public Vendor(int id, string name, int reliability)
        {
            this.Id = id;
            this.Name = name;
            this.Reliablity = reliability;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override string ToString()
        {
            return string.Format("{0}   (reliability {1}%)", Name, Reliablity);
        }
    }
}
