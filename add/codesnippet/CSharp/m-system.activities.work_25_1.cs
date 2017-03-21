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
                }
            };

            // Run the workflow.
            wfApp.Run();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            wfApp.Cancel();