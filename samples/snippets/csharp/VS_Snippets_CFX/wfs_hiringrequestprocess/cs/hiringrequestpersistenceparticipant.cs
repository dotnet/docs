//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
using System;
using System.Activities.Hosting;
using System.Activities.Persistence;
using System.Collections.Generic;
using System.Linq;


namespace Microsoft.Samples.HiringService
{
//<Snippet1>
    public class HiringRequestInfoPersistenceParticipant: PersistenceIOParticipant
    {
        public HiringRequestInfoPersistenceParticipant()
            : base(true, false)
        {
        }
//</Snippet1>
        protected override void Abort()
        {
            throw new NotImplementedException();
        }
    }
}
