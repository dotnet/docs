            ServiceDescription d = ServiceDescription.GetService(new CalculatorService());
            foreach (IServiceBehavior isb in d.Behaviors)
            {
                Console.WriteLine(isb.GetType());
            }
            Console.WriteLine();