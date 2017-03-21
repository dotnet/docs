            Activity wf = new Sequence
            {
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "Starting the workflow."
                     },
                     new Throw
                    {
                        Exception = new InArgument<Exception>((env) => 
                            new ApplicationException("Something unexpected happened."))
                    },
                    new WriteLine
                     {
                         Text = "Ending the workflow."
                     }
                 }
            };

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.OnUnhandledException = delegate(WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                // Display the unhandled exception.
                Console.WriteLine("OnUnhandledException in Workflow {0}\n{1}",
                    e.InstanceId, e.UnhandledException.Message);

                Console.WriteLine("ExceptionSource: {0} - {1}",
                    e.ExceptionSource.DisplayName, e.ExceptionSourceInstanceId);

                // Instruct the runtime to cancel the workflow.
                return UnhandledExceptionAction.Cancel;
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

            wfApp.Run();