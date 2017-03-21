      ' Define property Greeting.
      Dim greetingPropertyBuilder As PropertyBuilder = helloWorldTypeBuilder.DefineProperty _
                                 ("Greeting", PropertyAttributes.None, GetType(String), Nothing)

      ' Define the 'get_Greeting' method.
      Dim getGreetingMethod As MethodBuilder = helloWorldTypeBuilder.DefineMethod("get_Greeting", _
                              MethodAttributes.Public Or MethodAttributes.HideBySig Or _
                              MethodAttributes.SpecialName, GetType(String), Nothing)
      ' Generate IL code for 'get_Greeting' method.
      Dim methodIL As ILGenerator = getGreetingMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_0)
      methodIL.Emit(OpCodes.Ldfld, greetingFieldBuilder)
      methodIL.Emit(OpCodes.Ret)
      greetingPropertyBuilder.SetGetMethod(getGreetingMethod)