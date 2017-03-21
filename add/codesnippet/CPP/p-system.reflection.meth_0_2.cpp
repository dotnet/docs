
    // Display information about the local variables in the
    // method body.
    Console::WriteLine();
    for each (LocalVariableInfo^ lvi in mb->LocalVariables)
    {
        Console::WriteLine("Local variable: {0}", lvi);
    }