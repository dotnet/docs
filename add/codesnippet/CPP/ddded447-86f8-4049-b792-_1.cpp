      AppDomain^ currentDomain;
      AssemblyName^ myAssemblyName;
      
      // Get the current application domain for the current thread.
      currentDomain = AppDomain::CurrentDomain;
      myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      
      // Define a dynamic assembly in the 'currentDomain'.
      myAssemblyBuilder =
         currentDomain->DefineDynamicAssembly(
            myAssemblyName, AssemblyBuilderAccess::Run );
      
      // Define a dynamic module in "TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      
      // Define the initialized data field in the .sdata section of the PE file.
      array<Byte>^ temp0 = {01,00,01};
      FieldBuilder^ myFieldBuilder =
         myModuleBuilder->DefineInitializedData( "MyField", temp0,
            (FieldAttributes)(FieldAttributes::Static | FieldAttributes::Public) );
      myModuleBuilder->CreateGlobalFunctions();