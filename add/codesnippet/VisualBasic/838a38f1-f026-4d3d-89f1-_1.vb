      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      Dim myAsmBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      ' Create a dynamic module that can be saved as the specified DLL name.
      Dim myModuleBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule3", _
									"MyModule3.dll")