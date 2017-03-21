      ' Define the constructor.
      Dim constructorArgs As Type() = {GetType(String)}
      Dim myConstructorBuilder As ConstructorBuilder = helloWorldTypeBuilder.DefineConstructor _
                           (MethodAttributes.Public, CallingConventions.Standard, constructorArgs)
      ' Generate IL for the method.The constructor stores its argument in the private field.
      Dim myConstructorIL As ILGenerator = myConstructorBuilder.GetILGenerator()
      myConstructorIL.Emit(OpCodes.Ldarg_0)
      myConstructorIL.Emit(OpCodes.Ldarg_1)
      myConstructorIL.Emit(OpCodes.Stfld, myGreetingField)
      myConstructorIL.Emit(OpCodes.Ret)