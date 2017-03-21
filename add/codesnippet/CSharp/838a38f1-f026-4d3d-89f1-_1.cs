	   AppDomain myAppDomain = Thread.GetDomain(); 
	   AssemblyName myAsmName = new AssemblyName();
	   myAsmName.Name = "MyAssembly";
	   AssemblyBuilder myAsmBuilder = myAppDomain.DefineDynamicAssembly(
							myAsmName,
							AssemblyBuilderAccess.Run);
	   // Create a dynamic module that can be saved as the specified DLL name.
	   ModuleBuilder myModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule3",
									    "MyModule3.dll");