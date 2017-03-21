            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowInvoker invoker = new WorkflowInvoker(new LongRunningDiceRoll());

            invoker.InvokeCompleted += delegate(object sender, InvokeCompletedEventArgs args)
            {
                if (args.Cancelled == true)
                {
                    Console.WriteLine("Workflow was cancelled.");
                }
                else if (args.Error != null)
                {
                    Console.WriteLine("Exception: {0}\n{1}",
                        args.Error.GetType().FullName,
                        args.Error.Message);
                }
                else
                {
                    Console.WriteLine("The two dice are {0} and {1}.",
                        args.Outputs["D1"], args.Outputs["D2"]);
                }

                syncEvent.Set();
            };

            invoker.InvokeAsync("InvokeAsync Example");

            Console.WriteLine("Waiting for the workflow to complete.");

            // Wait for the workflow to complete.
            syncEvent.WaitOne();

            Console.WriteLine("The workflow is complete.");