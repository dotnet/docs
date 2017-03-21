      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      Dim myAsmBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      ' Create a dynamic module that can be saved as the specified DLL name. By
      ' specifying the third parameter as true, we can allow the emission of symbol info.
      Dim myModuleBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule4", _
									"MyModule4.dll", _
									True)