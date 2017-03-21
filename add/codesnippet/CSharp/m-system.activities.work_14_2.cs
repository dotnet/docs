            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(new DiceRoll());

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
                    Console.WriteLine("The two dice are {0} and {1}.",
                        e.Outputs["D1"], e.Outputs["D2"]);
                }
            };

           // Run the workflow.
            wfApp.Run();