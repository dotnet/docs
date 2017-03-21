   // Define the constructor.
   array<Type^>^ constructorArgs = {String::typeid};
   ConstructorBuilder^ myConstructorBuilder =
      helloWorldTypeBuilder->DefineConstructor( MethodAttributes::Public,
         CallingConventions::Standard, constructorArgs );
   // Generate IL for the method.The constructor stores its argument in the private field.
   ILGenerator^ myConstructorIL = myConstructorBuilder->GetILGenerator();
   myConstructorIL->Emit( OpCodes::Ldarg_0 );
   myConstructorIL->Emit( OpCodes::Ldarg_1 );
   myConstructorIL->Emit( OpCodes::Stfld, myGreetingField );
   myConstructorIL->Emit( OpCodes::Ret );