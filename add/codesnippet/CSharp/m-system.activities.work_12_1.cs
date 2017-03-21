            Activity wf = new Sequence()
            {
                Activities = 
                {
                    new WriteLine()
                    {
                        Text = "Before the 1 minute delay."
                    },
                    new Delay()
                    {
                        Duration = TimeSpan.FromMinutes(1)
                    },
                    new WriteLine()
                    {
                        Text = "After the 1 minute delay."
                    }
                }
            };

            WorkflowInvoker invoker = new WorkflowInvoker(wf);

            // This workflow completes successfully.
            invoker.Invoke(TimeSpan.FromMinutes(2));

            // This workflow does not complete and a TimeoutException
            // is thrown.
            try
            {
                invoker.Invoke(TimeSpan.FromSeconds(30));
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }