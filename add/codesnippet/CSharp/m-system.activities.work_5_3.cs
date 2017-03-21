            Activity wf = new WriteLine
            {
                Text = "Hello World."
            };

            WorkflowInvoker invoker = new WorkflowInvoker(wf);

            invoker.Invoke();