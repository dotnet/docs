      Dim currentDomain As AppDomain
      Dim myAssemblyName As AssemblyName
      ' Get the current application domain for the current thread.
      currentDomain = AppDomain.CurrentDomain
      myAssemblyName = New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Define a dynamic assembly in the 'currentDomain'.
      myAssemblyBuilder = _
            currentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)
      ' Define a dynamic module in "TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      ' Define the initialized data field in the .sdata section of the PE file.
      Dim myFieldBuilder As FieldBuilder = _
            myModuleBuilder.DefineInitializedData("MyField", New Byte() {1, 0, 1}, _
            FieldAttributes.Static Or FieldAttributes.Public)
      myModuleBuilder.CreateGlobalFunctions()