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

                // Instruct the runtime to terminate the workflow.
                return UnhandledExceptionAction.Terminate;

                // Other choices are UnhandledExceptionAction.Abort and 
                // UnhandledExceptionAction.Cancel
            };

            wfApp.Run();