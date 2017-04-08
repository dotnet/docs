//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities.Persistence;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Microsoft.Samples.PersistenceParticipants
{
//<Snippet2>
    public class StepCountExtension : PersistenceParticipant
    {
        static XNamespace stepCountNamespace = XNamespace.Get("urn:schemas-microsoft-com:Microsoft.Samples.WF/WorkflowInstances/properties");
        static XName currentCountName = stepCountNamespace.GetName("CurrentCount");

        int currentCount;

        public int CurrentCount
        {
            get
            {
                return this.currentCount;
            }
        }

        internal void IncrementStepCount()
        {
            this.currentCount += 1;
        }

        protected override void CollectValues(out IDictionary<XName, object> readWriteValues, out IDictionary<XName, object> writeOnlyValues)
        {
            readWriteValues = new Dictionary<XName, object>(1) { { currentCountName, this.currentCount } };
            writeOnlyValues = null;
        }

        protected override void PublishValues(IDictionary<XName, object> readWriteValues)
        {
            object loadedData;
            if (readWriteValues.TryGetValue(currentCountName, out loadedData))
            {
                this.currentCount = (int)loadedData;
            }
        }
    }
//</Snippet2>
}
