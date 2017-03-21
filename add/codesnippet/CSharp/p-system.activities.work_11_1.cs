            Activity wf = new WriteLine
            {
                Text = "Hello world."
            };

            WorkflowApplication wfApp = new WorkflowApplication(wf);

            Console.WriteLine("Id: {0}", wfApp.Id);