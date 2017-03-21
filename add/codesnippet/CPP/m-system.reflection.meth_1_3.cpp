    // Get the generic type definition from the closed method,
    // and show it's the same as the original definition.
    //
    MethodInfo^ miDef = miConstructed->GetGenericMethodDefinition();
    Console::WriteLine("\r\nThe definition is the same: {0}",
            miDef == mi);