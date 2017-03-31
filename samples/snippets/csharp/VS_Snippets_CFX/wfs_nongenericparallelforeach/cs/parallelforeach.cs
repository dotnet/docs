//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Activities;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Markup;

namespace Microsoft.Samples.Activities.Statements
{
    [Designer(typeof(Microsoft.Samples.Activities.Statements.Presentation.ParallelForEachDesigner))]
    [ContentProperty("Body")]
    public sealed class ParallelForEach : NativeActivity
    {
        Variable<bool> hasCompleted;
        CompletionCallback<bool> onConditionComplete;

        public ParallelForEach()
            : base()
        {
        }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<IEnumerable> Values
        {
            get;
            set;
        }

        [DefaultValue(null)]
        [DependsOn("Values")]
        public Activity<bool> CompletionCondition
        {
            get;
            set;
        }

        [Browsable(false)]
        [DefaultValue(null)]
        [DependsOn("CompletionCondition")]
        public ActivityAction<object> Body
        {
            get;
            set;
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            RuntimeArgument valuesArgument = new RuntimeArgument("Values", typeof(IEnumerable), ArgumentDirection.In, true);
            metadata.Bind(this.Values, valuesArgument);
            metadata.SetArgumentsCollection(new Collection<RuntimeArgument> { valuesArgument });

            // declare the CompletionCondition as a child
            if (this.CompletionCondition != null)
            {
                metadata.SetChildrenCollection(new Collection<Activity> { this.CompletionCondition });
            }

            // declare the hasCompleted variable
            if (this.CompletionCondition != null)
            {
                if (this.hasCompleted == null)
                {
                    this.hasCompleted = new Variable<bool>();
                }

                metadata.AddImplementationVariable(this.hasCompleted);
            }

            metadata.AddDelegate(this.Body);
        }
//<Snippet1>
        protected override void Execute(NativeActivityContext context)
        {
            IEnumerable values = this.Values.Get(context);
            if (values == null)
            {
                throw new InvalidOperationException("ParallelForEach requires a non-null Values argument.");
            }

            IEnumerator valueEnumerator = values.GetEnumerator();

            CompletionCallback onBodyComplete = new CompletionCallback(OnBodyComplete);
            while (valueEnumerator.MoveNext())
            {
                if (this.Body != null)
                {
                    context.ScheduleAction(this.Body, valueEnumerator.Current, onBodyComplete);
                }
            }
            IDisposable disposable = valueEnumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
//</Snippet1>
//<Snippet2>
        protected override void Cancel(NativeActivityContext context)
        {
            // If we don't have a completion condition then we can just
            // use default logic.
            if (this.CompletionCondition == null)
            {
                base.Cancel(context);
            }
            else
            {
                context.CancelChildren();
            }
        }
//</Snippet2>
        void OnBodyComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            // for the completion condition, we handle cancelation ourselves
            if (this.CompletionCondition != null && !this.hasCompleted.Get(context))
            {
                if (completedInstance.State != ActivityInstanceState.Closed && context.IsCancellationRequested)
                {
                    // If we hadn't completed before getting canceled
                    // or one of our iteration of body cancels then we'll consider
                    // ourself canceled.
                    context.MarkCanceled();
                    this.hasCompleted.Set(context, true);
                }
                else
                {
                    if (this.onConditionComplete == null)
                    {
                        this.onConditionComplete = new CompletionCallback<bool>(OnConditionComplete);
                    }
                    context.ScheduleActivity(CompletionCondition, this.onConditionComplete);
                }
            }
        }

        void OnConditionComplete(NativeActivityContext context, ActivityInstance completedInstance, bool result)
        {
            if (result)
            {
                context.CancelChildren();
                this.hasCompleted.Set(context, true);
            }
        }
    }
}
