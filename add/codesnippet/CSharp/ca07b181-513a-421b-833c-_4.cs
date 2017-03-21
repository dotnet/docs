            int dividend = 500;
            int divisor = 36;

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("Dividend", dividend);
            arguments.Add("Divisor", divisor);

            Activity wf = new Divide();

            IDictionary<string, object> outputs =
                WorkflowInvoker.Invoke(wf, arguments);

            Console.WriteLine("{0} / {1} = {2} Remainder {3}",
                dividend, divisor, outputs["Result"], outputs["Remainder"]);