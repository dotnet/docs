      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      Dim myAsmBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      
      ' Create a transient dynamic module. Since no DLL name is specified with
      ' this constructor, it can not be saved. By specifying the second parameter
      ' of the constructor as false, we can suppress the emission of symbol info.
      Dim myModuleBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule2", _
										False)