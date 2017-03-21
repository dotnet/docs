//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System.Activities;
using System.Collections.ObjectModel;

namespace Microsoft.Samples.Scenarios.Common.Activities
{

    public sealed class MyWhile : NativeActivity
    {
        Collection<Variable> variables;

        public MyWhile()
        {
            this.variables = new Collection<Variable>();
        }

        public Collection<Variable> Variables
        {
            get
            {
                return this.variables;
            }
        }

        public Activity<bool> Condition  { get; set; }
        public Activity Body { get; set; }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            //call base.CacheMetadata to add the Variables, Condition, and Body to the activity's metadata
            base.CacheMetadata(metadata);

            if (this.Condition == null)
            {
                //MyWhile requires a Condition expression so - add a validation error if one isn't present
                metadata.AddValidationError(string.Format("While {0} requires a Condition", this.DisplayName));
                return;
            }
        }        

        protected override void Execute(NativeActivityContext context)
        {
            InternalExecute(context, null);
        }

        void InternalExecute(NativeActivityContext context, ActivityInstance instance)
        {
            //schedule the Condition for evaluation
            context.ScheduleActivity(this.Condition, new CompletionCallback<bool>(OnEvaluateConditionCompleted));
        }

        void OnEvaluateConditionCompleted(NativeActivityContext context, ActivityInstance instance, bool result)
        {            
            if (result)
            {
                if (this.Body != null)
                {
                    //if the Condition evaluates to true and the Body is not null
                    //schedule the Body with the InternalExecute as the CompletionCallback
                    context.ScheduleActivity(this.Body, InternalExecute);
                }
            }

        }
    }
}
