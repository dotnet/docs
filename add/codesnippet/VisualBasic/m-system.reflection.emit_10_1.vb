      ' Define a constructor of the dynamic class.
      Dim myConstructorBuilder As ConstructorBuilder = _ 
          myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _ 
                                          myConstructorArgs)
      ' Get a reference to the module that contains this constructor.
      Dim myModule As [Module] = myConstructorBuilder.GetModule()
      Console.WriteLine("Module Name : " + myModule.Name)
      ' Get the 'MethodToken' that represents the token for this constructor.
      Dim myMethodToken As MethodToken = myConstructorBuilder.GetToken()
      Console.WriteLine("Constructor Token is : " + myMethodToken.Token.ToString())
      ' Get the method implementation flags for this constructor.
      Dim myMethodImplAttributes As MethodImplAttributes = _
          myConstructorBuilder.GetMethodImplementationFlags()
      Console.WriteLine("MethodImplAttributes : " + myMethodImplAttributes.ToString())
      ' Generate IL for the method, call its base class constructor and store the arguments
      ' in the private field.
      Dim myILGenerator3 As ILGenerator = myConstructorBuilder.GetILGenerator()
      myILGenerator3.Emit(OpCodes.Ldarg_0)
      Dim myConstructorInfo As ConstructorInfo = GetType(Object).GetConstructor(New Type() {})
      myILGenerator3.Emit(OpCodes.Call, myConstructorInfo)
      myILGenerator3.Emit(OpCodes.Ldarg_0)
      myILGenerator3.Emit(OpCodes.Ldarg_1)
      myILGenerator3.Emit(OpCodes.Stfld, myGreetingField)
      myILGenerator3.Emit(OpCodes.Ret)
      ' Add a method to the type. 
      myMethodBuilder = _ 
           myTypeBuilder.DefineMethod("HelloWorld", MethodAttributes.Public, Nothing, Nothing)
      ' Generate IL for the method.
      Dim myILGenerator2 As ILGenerator = myMethodBuilder.GetILGenerator()
      myILGenerator2.EmitWriteLine("Hello World from global")
      myILGenerator2.Emit(OpCodes.Ret)
      myModuleBuilder.CreateGlobalFunctions()
      myType1 = myTypeBuilder.CreateType()

      ' Get the parameters of this constructor.
      Dim myParameterInfo As ParameterInfo() = myConstructorBuilder.GetParameters()
      Dim i As Integer
      For i = 0 To myParameterInfo.Length - 1
         Console.WriteLine _ 
                 ("Declaration type : " + myParameterInfo(i).Member.DeclaringType.ToString())
      Next i