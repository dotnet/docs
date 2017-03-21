	// myModBuilder is an instance of ModuleBuilder.
	// Note that for the use of PermissionSet and SecurityAction,
	// the namespaces System.Security and System.Security.Permissions
	// should be included.
	
	TypeBuilder myTypeBuilder = myModBuilder.DefineType("MyType",
				    	TypeAttributes.Public);

						
	MethodBuilder myMethod1 = myTypeBuilder.DefineMethod("MyMethod",
						MethodAttributes.Public, 
						typeof(int),
						new Type[] 
						{typeof(int), typeof(int)});	

	PermissionSet myMethodPermissions = new PermissionSet(
				PermissionState.Unrestricted);
	
	myMethod1.AddDeclarativeSecurity(SecurityAction.Demand,
					 myMethodPermissions);
	