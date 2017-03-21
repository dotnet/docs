    // Show whether the EXE assembly was loaded from the GAC or from a
    // private subdirectory.
    Console::WriteLine("Did the {0} assembly load from the GAC? {1}",
        Assembly::GetExecutingAssembly(),
        RuntimeEnvironment::FromGlobalAccessCache(
        Assembly::GetExecutingAssembly()));