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

            // This workflow completes successfully.
            WorkflowInvoker.Invoke(wf, TimeSpan.FromMinutes(2));

            // This workflow does not complete and a TimeoutException
            // is thrown.
            try
            {
                WorkflowInvoker.Invoke(wf, TimeSpan.FromSeconds(30));
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }