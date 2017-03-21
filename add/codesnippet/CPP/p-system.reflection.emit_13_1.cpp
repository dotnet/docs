    // Display the default value for InitLocals.
    if (hello->InitLocals)
    {
        Console::Write("\r\nThis method contains verifiable code.");
    }
    else
    {
        Console::Write("\r\nThis method contains unverifiable code.");
    }
    Console::WriteLine(" (InitLocals = {0})", hello->InitLocals);