      Dim currentDomain As AppDomain
      Dim myAssemblyName As AssemblyName
      Dim myMethodBuilder As MethodBuilder = Nothing
      Dim myILGenerator As ILGenerator
      
      ' Get the current application domain for the current thread.
      currentDomain = AppDomain.CurrentDomain
      myAssemblyName = New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      
      ' Define a dynamic assembly in the 'currentDomain'.
      myAssemblyBuilder = currentDomain.DefineDynamicAssembly(myAssemblyName, _
                                                         AssemblyBuilderAccess.RunAndSave)
      ' Define a dynamic module in "TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      
      ' Define a global method in the 'TempModule' module.
      myMethodBuilder = myModuleBuilder.DefineGlobalMethod("MyMethod1", MethodAttributes.Static _
                                                Or MethodAttributes.Public, Nothing, Nothing)
      myILGenerator = myMethodBuilder.GetILGenerator()
      myILGenerator.EmitWriteLine("Hello World from global method.")
      myILGenerator.Emit(OpCodes.Ret)
      ' Fix up the 'TempModule' module .
      myModuleBuilder.CreateGlobalFunctions()