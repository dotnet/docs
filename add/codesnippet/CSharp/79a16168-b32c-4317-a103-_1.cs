        // Show whether the EXE assembly was loaded from the GAC or from a private subdirectory.
        Assembly assem = typeof(App).Assembly;
        Console.WriteLine("Did the {0} assembly load from the GAC? {1}",
           assem, RuntimeEnvironment.FromGlobalAccessCache(assem));