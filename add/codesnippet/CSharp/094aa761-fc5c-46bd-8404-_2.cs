        static void BeginInvokeExample()
        {
            WorkflowInvoker invoker = new WorkflowInvoker(new LongRunningDiceRoll());

            string userState = "BeginInvoke example";
            IAsyncResult result = invoker.BeginInvoke(new AsyncCallback(WorkflowCompletedCallback), userState);

            // You can inspect result from the host to determine if the workflow
            // is complete.
            Console.WriteLine("result.IsCompleted: {0}", result.IsCompleted);

            // The results of the workflow are retrieved by calling EndInvoke, which
            // can be called from the callback or from the host. If called from the
            // host, it blocks until the workflow completes. If a callback is not
            // required, pass null for the callback parameter.
            Console.WriteLine("Waiting for the workflow to complete.");
            IDictionary<string, object> outputs = invoker.EndInvoke(result);

            Console.WriteLine("The two dice are {0} and {1}.",
                outputs["D1"], outputs["D2"]);
        }

        static void WorkflowCompletedCallback(IAsyncResult result)
        {
            Console.WriteLine("Workflow complete.");
        }