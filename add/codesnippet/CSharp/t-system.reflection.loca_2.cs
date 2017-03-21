
        // Display information about the local variables in the
        // method body.
        Console.WriteLine();
        foreach (LocalVariableInfo lvi in mb.LocalVariables)
        {
            Console.WriteLine("Local variable: {0}", lvi);
        }