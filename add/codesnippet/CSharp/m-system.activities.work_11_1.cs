            string input = Console.ReadLine();

            WorkflowApplication application = new WorkflowApplication(activity);
            application.InstanceStore = instanceStore;

            application.Completed = (workflowApplicationCompletedEventArgs) =>
            {
                Console.WriteLine("\nWorkflowApplication has Completed in the {0} state.", workflowApplicationCompletedEventArgs.CompletionState);
            };

            application.Unloaded = (workflowApplicationEventArgs) =>
            {
                Console.WriteLine("WorkflowApplication has Unloaded\n");
                instanceUnloaded.Set();
            };

            application.Load(id);

            //this resumes the bookmark setup by readline
            application.ResumeBookmark(readLineBookmark, input);

            instanceUnloaded.WaitOne();