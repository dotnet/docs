            IDictionary<string, object> outputs =
                WorkflowInvoker.Invoke(new DiceRoll());

            Console.WriteLine("The two dice are {0} and {1}.",
                outputs["D1"], outputs["D2"]);