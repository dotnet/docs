
        ' Display information about the local variables in the
        ' method body.
        Console.WriteLine()
        For Each lvi As LocalVariableInfo In mb.LocalVariables
            Console.WriteLine("Local variable: {0}", lvi)
        Next