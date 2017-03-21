	   AppDomain myAppDomain = Thread.GetDomain(); 
	   AssemblyName myAsmName = new AssemblyName();
	   myAsmName.Name = "MyAssembly";
	   AssemblyBuilder myAsmBuilder = myAppDomain.DefineDynamicAssembly(
							myAsmName,
							AssemblyBuilderAccess.Run);
	   // Create a dynamic module that can be saved as the specified DLL name. By
	   // specifying the third parameter as true, we can allow the emission of symbol info.
	   ModuleBuilder myModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule4",
									    "MyModule4.dll",
									     true);