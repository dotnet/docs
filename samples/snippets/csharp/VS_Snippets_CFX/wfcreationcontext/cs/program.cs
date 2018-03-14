using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ServiceModel.Activities;

namespace WFCreationContext
{
    class HostingWorkflowCreationContext : WorkflowCreationContext
    {
        public Guid InstanceId { get; set; }
        public object UserState { get; set; }

        // <Snippet0>
        protected override IAsyncResult OnBeginWorkflowCompleted(ActivityInstanceState completionState, IDictionary<string, object> workflowOutputs,
            Exception faultedReason, TimeSpan timeout, AsyncCallback callback, object state)
        {
            if (completionState == ActivityInstanceState.Faulted)
            {
                Console.WriteLine("InstanceId :" + InstanceId + " OnBeginWorkflowTerminated");
            }
            else if (completionState == ActivityInstanceState.Canceled)
            {
                Console.WriteLine("InstanceId :" + InstanceId + " OnBeginWorkflowCanceled");
            }
            else
            {
                Console.WriteLine("InstanceId :" + InstanceId + " OnBeginWorkflowCompleted");
                WorkflowHostingResponseContext responseContext = UserState as WorkflowHostingResponseContext;
                if (responseContext != null)
                {
                    foreach (object value in workflowOutputs.Values)
                    {
                        responseContext.SendResponse(value, null);
                        break;
                    }
                }
            }
            return base.OnBeginWorkflowCompleted(completionState, workflowOutputs, faultedReason, timeout, callback, state);
        }
        // </Snippet0>
        // <Snippet1>
        protected override void OnEndWorkflowCompleted(IAsyncResult result)
        {
            base.OnEndWorkflowCompleted(result);
        }
        // </Snippet1>

        // <Snippet2>
        protected override void OnAbort()
        {
            Console.WriteLine("InstanceId :" + InstanceId + " OnBeginWorkflowAborted");
            base.OnAbort();
        }
        // </Snippet2>
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
