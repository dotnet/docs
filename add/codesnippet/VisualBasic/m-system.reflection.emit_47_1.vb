      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      Dim myAsmBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      
      ' Create a transient dynamic module. Since no DLL name is specified with
      ' this constructor, it can not be saved. 
      Dim myModuleBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule1")