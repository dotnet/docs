//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities;
using System.Collections.ObjectModel;

namespace Microsoft.Samples.AccessingOperationContext.Client
{
    public sealed class SendInstanceIdScope : NativeActivity
    {
        Collection<Activity> children;
        Collection<Variable> variables;
        Variable<int> currentIndex;
        CompletionCallback onChildComplete;

        public SendInstanceIdScope()
            : base()
        {
            this.children = new Collection<Activity>();
            this.variables = new Collection<Variable>();
            this.currentIndex = new Variable<int>();
        }

        public Collection<Activity> Activities
        {
            get
            {
                return this.children;
            }
        }

        public Collection<Variable> Variables
        {
            get
            {
                return this.variables;
            }
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            //call base.CacheMetadata to add the Activities and Variables to this activity's metadata
            base.CacheMetadata(metadata);
            //add the private implementation variable: currentIndex 
            metadata.AddImplementationVariable(this.currentIndex);
        }

        protected override void Execute(
            NativeActivityContext context)
        {
            context.Properties.Add("SendInstanceIdCallback", new SendInstanceIdCallback() { InstanceId = context.WorkflowInstanceId });
            InternalExecute(context, null);
        }

        void InternalExecute(NativeActivityContext context, ActivityInstance instance)
        {
            //grab the index of the current Activity
            int currentActivityIndex = this.currentIndex.Get(context);
            if (currentActivityIndex == Activities.Count)
            {
                //if the currentActivityIndex is equal to the count of MySequence's Activities
                //MySequence is complete
                return;
            }

            if (this.onChildComplete == null)
            {
                //on completion of the current child, have the runtime call back on this method
                this.onChildComplete = new CompletionCallback(InternalExecute);
            }

            //grab the next Activity in MySequence.Activities and schedule it
            Activity nextChild = Activities[currentActivityIndex];
            context.ScheduleActivity(nextChild, this.onChildComplete);

            //increment the currentIndex
            this.currentIndex.Set(context, ++currentActivityIndex);
        }
    }
}
