   // Mark the class as implementing 'IHello' interface.
   helloWorldTypeBuilder->AddInterfaceImplementation( IHello::typeid );
   MethodBuilder^ myMethodBuilder =
      helloWorldTypeBuilder->DefineMethod( "SayHello",
         (MethodAttributes)(MethodAttributes::Public | MethodAttributes::Virtual),
         nullptr,
         nullptr );
   // Generate IL for 'SayHello' method.
   ILGenerator^ myMethodIL = myMethodBuilder->GetILGenerator();
   myMethodIL->EmitWriteLine( myGreetingField );
   myMethodIL->Emit( OpCodes::Ret );
   MethodInfo^ sayHelloMethod = IHello::typeid->GetMethod( "SayHello" );
   helloWorldTypeBuilder->DefineMethodOverride( myMethodBuilder, sayHelloMethod );