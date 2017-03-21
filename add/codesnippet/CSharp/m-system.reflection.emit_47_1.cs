	   AppDomain myAppDomain = Thread.GetDomain(); 
	   AssemblyName myAsmName = new AssemblyName();
	   myAsmName.Name = "MyAssembly";
	   AssemblyBuilder myAsmBuilder = myAppDomain.DefineDynamicAssembly(
							myAsmName,
							AssemblyBuilderAccess.Run);

	   // Create a transient dynamic module. Since no DLL name is specified with
	   // this constructor, it can not be saved. 
	   ModuleBuilder myModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule1");