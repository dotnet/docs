            int dividend = 500;
            int divisor = 36;

            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("Dividend", dividend);
            inputs.Add("Divisor", divisor);

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(new Divide(), inputs);

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
                    Console.WriteLine("{0} / {1} = {2} Remainder {3}",
                        dividend, divisor, e.Outputs["Result"], e.Outputs["Remainder"]);
                }
            };

            // Run the workflow.
            wfApp.Run();