      ' Define a dynamic module in "TempAssembly" assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      ' Define a runtime class with specified name and attributes.
      Dim myTypeBuilder As TypeBuilder = _
                  myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myParamArray() As Type = New Type() {GetType(Array)}
      ' Add 'SortArray' method to the class, with the given signature.
      Dim myMethod As MethodBuilder = _
         myTypeBuilder.DefineMethod("SortArray", MethodAttributes.Public, _
         GetType(Array), myParamArray)

      Dim myArrayClass(0) As Type
      Dim parameterTypes() As Type = New Type() {GetType(Array)}
      ' Get the 'MethodInfo' object corresponding to 'Sort' method of 'Array' class.
      Dim myMethodInfo As MethodInfo = _
         myModuleBuilder.GetArrayMethod(myArrayClass.GetType(), "Sort", _
         CallingConventions.Standard, Nothing, parameterTypes)
      ' Get the token corresponding to 'Sort' method of 'Array' class.
      Dim myMethodToken As MethodToken = _
            myModuleBuilder.GetArrayMethodToken(myArrayClass.GetType(), _
            "Sort", CallingConventions.Standard, Nothing, parameterTypes)
      Console.WriteLine("Token used by module to identify the 'Sort' method" + _
                        " of 'Array' class is : {0:x} ", myMethodToken.Token)
      Dim methodIL As ILGenerator = myMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_1)
      methodIL.Emit(OpCodes.Call, myMethodInfo)
      methodIL.Emit(OpCodes.Ldarg_1)
      methodIL.Emit(OpCodes.Ret)
      ' Complete the creation of type.
      myTypeBuilder.CreateType()