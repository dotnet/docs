      // Define a dynamic module in "TempAssembly" assembly.
      ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->
         DefineDynamicModule( "TempModule" );

      // Define a runtime class with specified name and attributes.
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType(
         "TempClass", TypeAttributes::Public );
      array<Type^>^ paramArray = { Array::typeid };
      // Add 'SortArray' method to the class, with the given signature.
      MethodBuilder^ myMethod = myTypeBuilder->DefineMethod( "SortArray",
         MethodAttributes::Public, Array::typeid, paramArray );

      array<Type^>^ myArrayClass = gcnew array<Type^>( 1 );
      array<Type^>^ parameterTypes = { Array::typeid };
      // Get the 'MethodInfo' object corresponding to 'Sort' method of 'Array' class.
      MethodInfo^ myMethodInfo = myModuleBuilder->GetArrayMethod(
         myArrayClass->GetType(), "Sort", CallingConventions::Standard,
         nullptr, parameterTypes );

      // Get the token corresponding to 'Sort' method of 'Array' class.
      MethodToken myMethodToken = myModuleBuilder->GetArrayMethodToken(
         myArrayClass->GetType(), "Sort", CallingConventions::Standard,
         nullptr, parameterTypes );
      Console::WriteLine( "Token used by module to identify the 'Sort' method"
         + " of 'Array' class is : {0:x} ", myMethodToken.Token );

      ILGenerator^ methodIL = myMethod->GetILGenerator();
      methodIL->Emit( OpCodes::Ldarg_1 );
      methodIL->Emit( OpCodes::Call, myMethodInfo );
      methodIL->Emit( OpCodes::Ldarg_1 );
      methodIL->Emit( OpCodes::Ret );

      // Complete the creation of type.
      myTypeBuilder->CreateType();