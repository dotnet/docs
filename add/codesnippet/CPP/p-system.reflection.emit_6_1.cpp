    // Use the IsGenericMethod property to find out if a
    // dynamic method is generic, and IsGenericMethodDefinition
    // to find out if it defines a generic method.
    Console::WriteLine("Is SampleMethod generic? {0}",
        sampleMethodBuilder->IsGenericMethod);
    Console::WriteLine(
        "Is SampleMethod a generic method definition? {0}",
        sampleMethodBuilder->IsGenericMethodDefinition);