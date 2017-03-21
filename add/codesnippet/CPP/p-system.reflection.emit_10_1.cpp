    // Display the declaring type, which is always null for dynamic
    // methods.
    if (hello->DeclaringType == nullptr)
    {
        Console::WriteLine("\r\nDeclaringType is always null for dynamic methods.");
    }
    else
    {
        Console::WriteLine("DeclaringType: {0}", hello->DeclaringType);
    }