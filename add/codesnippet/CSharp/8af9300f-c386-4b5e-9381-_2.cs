            int x = 1;
            int y = 2;

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("X", x);
            arguments.Add("Y", y);

            Console.WriteLine("Invoking Add.");

            int result = WorkflowInvoker.Invoke(new Add(), arguments);

            Console.WriteLine("{0} + {1} = {2}", x, y, result);