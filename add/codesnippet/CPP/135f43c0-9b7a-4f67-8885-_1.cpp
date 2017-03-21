      AppDomain^ currentDomain;
      AssemblyName^ myAssemblyName;
      MethodBuilder^ myMethodBuilder = nullptr;
      ILGenerator^ myILGenerator;
      
      // Get the current application domain for the current thread.
      currentDomain = AppDomain::CurrentDomain;
      myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      
      // Define a dynamic assembly in the 'currentDomain'.
      myAssemblyBuilder = 
         currentDomain->DefineDynamicAssembly(
            myAssemblyName, AssemblyBuilderAccess::RunAndSave );
      
      // Define a dynamic module in "TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      
      // Define a global method in the 'TempModule' module.
      myMethodBuilder = myModuleBuilder->DefineGlobalMethod(
         "MyMethod1", (MethodAttributes)(MethodAttributes::Static | MethodAttributes::Public),
         nullptr, nullptr );
      myILGenerator = myMethodBuilder->GetILGenerator();
      myILGenerator->EmitWriteLine( "Hello World from global method." );
      myILGenerator->Emit( OpCodes::Ret );
      
      // Fix up the 'TempModule' module .
      myModuleBuilder->CreateGlobalFunctions();