      // Define a constructor of the dynamic class.
      ConstructorBuilder myConstructorBuilder = myTypeBuilder.DefineConstructor(
         MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);
      // Get a reference to the module that contains this constructor.
      Module myModule = myConstructorBuilder.GetModule();
      Console.WriteLine("Module Name : " + myModule.Name);
      // Get the 'MethodToken' that represents the token for this constructor.
      MethodToken myMethodToken = myConstructorBuilder.GetToken();
      Console.WriteLine("Constructor Token is : " + myMethodToken.Token);
      // Get the method implementation flags for this constructor.
      MethodImplAttributes myMethodImplAttributes = myConstructorBuilder.GetMethodImplementationFlags();
      Console.WriteLine("MethodImplAttributes : "  + myMethodImplAttributes);