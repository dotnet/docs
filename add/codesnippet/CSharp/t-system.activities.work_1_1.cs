            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Delay
                     {
                         Duration = TimeSpan.FromSeconds(5)
                     },
                     new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Subscribe to any desired workflow lifecycle events.
            wfApp.Completed = delegate(WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    Console.WriteLine("Workflow {0} Terminated.", e.InstanceId);
                    Console.WriteLine("Exception: {0}\n{1}",
                        e.TerminationException.GetType().FullName,
                        e.TerminationException.Message);
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    Console.WriteLine("Workflow {0} Canceled.", e.InstanceId);
                }
                else
                {
                    Console.WriteLine("Workflow {0} Completed.", e.InstanceId);

                    // Outputs can be retrieved from the Outputs dictionary,
                    // keyed by argument name.
                    // Console.WriteLine("The winner is {0}.", e.Outputs["Winner"]);
                }
            };

            wfApp.Aborted = delegate(WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine("Workflow {0} Aborted.", e.InstanceId);
                Console.WriteLine("Exception: {0}\n{1}",
                    e.Reason.GetType().FullName,
                    e.Reason.Message);
            };
            
            wfApp.Idle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                // Perform any processing that should occur
                // when a workflow goes idle. If the workflow can persist,
                // both Idle and PersistableIdle are called in that order.
                Console.WriteLine("Workflow {0} Idle.", e.InstanceId);
            };

            wfApp.PersistableIdle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                // Instruct the runtime to persist and unload the workflow
                return PersistableIdleAction.Unload;
            };

            wfApp.Unloaded = delegate(WorkflowApplicationEventArgs e)
            {
                Console.WriteLine("Workflow {0} Unloaded.", e.InstanceId);
            };

            wfApp.OnUnhandledException = delegate(WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine("OnUnhandledException in Workflow {0}\n{1}",
                    e.InstanceId, e.UnhandledException.Message);

                Console.WriteLine("ExceptionSource: {0} - {1}",
                    e.ExceptionSource.DisplayName, e.ExceptionSourceInstanceId);

                // Instruct the runtime to terminate the workflow.
                // Other choices are Abort and Cancel
                return UnhandledExceptionAction.Terminate;
            };

            // Run the workflow.
            wfApp.Run();