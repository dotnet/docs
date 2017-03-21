//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities.Tracking;
using System.Threading;

namespace Microsoft.Samples.TransactedReceiveScope
{

    public class EventTrackingParticipant : TrackingParticipant
    {
        private AutoResetEvent syncEvent = new AutoResetEvent(false);

        public EventTrackingParticipant(AutoResetEvent syncEvent)
        {
            this.syncEvent = syncEvent;
        }

        protected override void Track(TrackingRecord trackingRecord, TimeSpan timeout)
        {
            WorkflowInstanceRecord record = trackingRecord as WorkflowInstanceRecord;
            if (record != null)
            {
                if (record.State == WorkflowInstanceStates.Aborted || record.State == WorkflowInstanceStates.Completed || record.State == WorkflowInstanceStates.UnhandledException)
                {
                    syncEvent.Set();
                }
            }
        }
    }
}
