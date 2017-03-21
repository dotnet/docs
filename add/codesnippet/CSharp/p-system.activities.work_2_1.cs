            wfApp.Aborted = delegate(WorkflowApplicationAbortedEventArgs e)
            {
                // Display the exception that caused the workflow
                // to abort.
                Console.WriteLine("Workflow {0} Aborted.", e.InstanceId);
                Console.WriteLine("Exception: {0}\n{1}",
                    e.Reason.GetType().FullName,
                    e.Reason.Message);
            };