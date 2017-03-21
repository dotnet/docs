
        // Display exception handling clauses.
        Console.WriteLine();
        foreach (ExceptionHandlingClause ehc in mb.ExceptionHandlingClauses)
        {
            Console.WriteLine(ehc.Flags.ToString());

            // The FilterOffset property is meaningful only for Filter
            // clauses. The CatchType property is not meaningful for 
            // Filter or Finally clauses. 
            switch (ehc.Flags)
            {
                case ExceptionHandlingClauseOptions.Filter:
                    Console.WriteLine("        Filter Offset: {0}", 
                        ehc.FilterOffset);
                    break;
                case ExceptionHandlingClauseOptions.Finally:
                    break;
                default:
                    Console.WriteLine("    Type of exception: {0}", 
                        ehc.CatchType);
                    break;
            }

            Console.WriteLine("       Handler Length: {0}", ehc.HandlerLength);
            Console.WriteLine("       Handler Offset: {0}", ehc.HandlerOffset);
            Console.WriteLine("     Try Block Length: {0}", ehc.TryLength);
            Console.WriteLine("     Try Block Offset: {0}", ehc.TryOffset);
        }