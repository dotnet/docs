      ' Mark the class as implementing 'IHello' interface.
      helloWorldTypeBuilder.AddInterfaceImplementation(GetType(IHello))
      Dim myMethodBuilder As MethodBuilder = helloWorldTypeBuilder.DefineMethod("SayHello", _
                           MethodAttributes.Public Or MethodAttributes.Virtual, Nothing, Nothing)
      ' Generate IL for 'SayHello' method.
      Dim myMethodIL As ILGenerator = myMethodBuilder.GetILGenerator()
      myMethodIL.EmitWriteLine(myGreetingField)
      myMethodIL.Emit(OpCodes.Ret)
      Dim sayHelloMethod As MethodInfo = GetType(IHello).GetMethod("SayHello")
      helloWorldTypeBuilder.DefineMethodOverride(myMethodBuilder, sayHelloMethod)