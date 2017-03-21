            WorkflowInvoker invoker = new WorkflowInvoker(BuildSampleWorkflow());
            invoker.Extensions.Add(customTrackingParticipant);

            invoker.Invoke();