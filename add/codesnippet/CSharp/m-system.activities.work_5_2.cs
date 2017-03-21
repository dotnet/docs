            WorkflowInvoker invoker = new WorkflowInvoker(new DiceRoll());

            IDictionary<string, object> outputs =
                invoker.Invoke();

            Console.WriteLine("The two dice are {0} and {1}.",
                outputs["D1"], outputs["D2"]);

            outputs = invoker.Invoke();

            Console.WriteLine("The next two dice are {0} and {1}.",
                outputs["D1"], outputs["D2"]);