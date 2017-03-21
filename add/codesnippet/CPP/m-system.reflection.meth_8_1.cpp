
      MethodBuilder^ myMethodBuilder = nullptr;
      AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;
      // Create assembly in current CurrentDomain.
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      // Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      // Create a type in the module.
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "TempClass", TypeAttributes::Public );
      FieldBuilder^ myGreetingField = myTypeBuilder->DefineField( "Greeting",
         String::typeid, FieldAttributes::Public );
      array<Type^>^myConstructorArgs = {String::typeid};
      // Define a constructor of the dynamic class.
      ConstructorBuilder^ myConstructorBuilder = myTypeBuilder->DefineConstructor(
         MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );
      // Get a reference to the module that contains this constructor.
      Module^ myModule = myConstructorBuilder->GetModule();
      Console::WriteLine( "Module Name : {0}", myModule->Name );
      // Get the 'MethodToken' that represents the token for this constructor.
      MethodToken myMethodToken = myConstructorBuilder->GetToken();
      Console::WriteLine( "Constructor Token is : {0}", myMethodToken.Token );
      // Get the method implementation flags for this constructor.
      MethodImplAttributes myMethodImplAttributes = myConstructorBuilder->GetMethodImplementationFlags();
      Console::WriteLine( "MethodImplAttributes : {0}", myMethodImplAttributes );