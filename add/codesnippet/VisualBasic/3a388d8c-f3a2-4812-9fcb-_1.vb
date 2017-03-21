      ' Define a public class named "HelloWorld" in the assembly.
      Dim helloWorldTypeBuilder As TypeBuilder = myModule.DefineType("HelloWorld", _
                                                                           TypeAttributes.Public)
      ' Define a private String field named "m_greeting" in "HelloWorld" class.
      Dim greetingFieldBuilder As FieldBuilder = helloWorldTypeBuilder.DefineField _
                                       ("m_greeting", GetType(String), FieldAttributes.Private)
      ' Create constructor args and define constructor.
      Dim constructorArgs As Type() = {GetType(String)}
      Dim constructor As ConstructorBuilder = helloWorldTypeBuilder.DefineConstructor _
                           (MethodAttributes.Public, CallingConventions.Standard, constructorArgs)

      ' Generate IL code for the method.The constructor stores its argument in the private field.
      Dim constructorIL As ILGenerator = constructor.GetILGenerator()
      constructorIL.Emit(OpCodes.Ldarg_0)
      constructorIL.Emit(OpCodes.Ldarg_1)
      constructorIL.Emit(OpCodes.Stfld, greetingFieldBuilder)
      constructorIL.Emit(OpCodes.Ret)
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

      ' Define the set_Greeting method.
      Dim methodArgs As Type() = {GetType(String)}
      Dim setGreetingMethod As MethodBuilder = helloWorldTypeBuilder.DefineMethod _
            ("set_Greeting", MethodAttributes.Public Or MethodAttributes.HideBySig Or _
                                    MethodAttributes.SpecialName, Nothing, methodArgs)

      ' Generate IL code for set_Greeting method.
      methodIL = setGreetingMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_0)
      methodIL.Emit(OpCodes.Ldarg_1)
      methodIL.Emit(OpCodes.Stfld, greetingFieldBuilder)
      methodIL.Emit(OpCodes.Ret)
      greetingPropertyBuilder.SetSetMethod(setGreetingMethod)