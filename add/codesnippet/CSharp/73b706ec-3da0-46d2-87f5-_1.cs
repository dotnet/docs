    // Import the service into the Code-DOM tree. This creates proxy code
    // that uses the service.
    ServiceDescriptionImportWarnings warning = importer.Import(nmspace,unit);

    if (warning == 0)
    {
        // Generate and print the proxy code in C#.
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        provider.GenerateCodeFromCompileUnit(unit, Console.Out, new CodeGeneratorOptions() );
    }
    else
    {
        // Print an error message.
        Console.WriteLine(warning); 
    }