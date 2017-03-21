
        ' Display exception handling clauses.
        Console.WriteLine()
        For Each ehc As ExceptionHandlingClause In mb.ExceptionHandlingClauses
            Console.WriteLine(ehc.Flags.ToString())

            ' The FilterOffset property is meaningful only for Filter
            ' clauses. The CatchType property is not meaningful for 
            ' Filter or Finally clauses. 
            Select Case ehc.Flags
                Case ExceptionHandlingClauseOptions.Filter
                    Console.WriteLine("        Filter Offset: {0}", _
                        ehc.FilterOffset)
                Case ExceptionHandlingClauseOptions.Finally
                Case Else
                    Console.WriteLine("    Type of exception: {0}", _
                        ehc.CatchType)
            End Select

            Console.WriteLine("       Handler Length: {0}", ehc.HandlerLength)
            Console.WriteLine("       Handler Offset: {0}", ehc.HandlerOffset)
            Console.WriteLine("     Try Block Length: {0}", ehc.TryLength)
            Console.WriteLine("     Try Block Offset: {0}", ehc.TryOffset)
        Next