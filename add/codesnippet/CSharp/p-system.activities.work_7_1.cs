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

                    // Retrieve the outputs of the workflow.
                    foreach (var kvp in e.Outputs)
                    {
                        Console.WriteLine("Name: {0} - Value {1}",
                            kvp.Key, kvp.Value);
                    }

                    // Outputs can be directly accessed by argument name.
                    Console.WriteLine("The winner is {0}.", e.Outputs["Winner"]);
                }
            };