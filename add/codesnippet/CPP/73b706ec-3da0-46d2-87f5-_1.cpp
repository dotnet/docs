   // Import the service into the Code-DOM tree. This creates proxy code
   // that uses the service.
   ServiceDescriptionImportWarnings warning = importer->Import(nmspace,unit);
   if ( warning == (ServiceDescriptionImportWarnings)0 )
   {
      // Generate and print the proxy code in C#.
      CodeDomProvider^ provider = CodeDomProvider::CreateProvider( "CSharp" );
      ICodeGenerator^ generator = provider->CreateGenerator();
      generator->GenerateCodeFromCompileUnit( unit, Console::Out, gcnew CodeGeneratorOptions );
   }
   else
   {
      // Print an error message.
      Console::WriteLine( warning );
   }