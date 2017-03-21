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