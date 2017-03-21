            wfApp.Unloaded = delegate(WorkflowApplicationEventArgs e)
            {
                Console.WriteLine("Workflow {0} unloaded.", e.InstanceId);
            };