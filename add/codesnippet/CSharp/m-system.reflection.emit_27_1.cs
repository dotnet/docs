      // Mark the class as implementing 'IHello' interface.
      helloWorldTypeBuilder.AddInterfaceImplementation(typeof(IHello));
      MethodBuilder myMethodBuilder =
         helloWorldTypeBuilder.DefineMethod("SayHello",
                              MethodAttributes.Public|MethodAttributes.Virtual,
                              null,
                              null);
      // Generate IL for 'SayHello' method.
      ILGenerator myMethodIL = myMethodBuilder.GetILGenerator();
      myMethodIL.EmitWriteLine(myGreetingField);
      myMethodIL.Emit(OpCodes.Ret);
     MethodInfo sayHelloMethod = typeof(IHello).GetMethod("SayHello");
     helloWorldTypeBuilder.DefineMethodOverride(myMethodBuilder,sayHelloMethod);