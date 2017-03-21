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
      // Generate IL for the method, call its base class constructor and store the arguments
      // in the private field.
      ILGenerator myILGenerator3 = myConstructorBuilder.GetILGenerator();
      myILGenerator3.Emit(OpCodes.Ldarg_0);
      ConstructorInfo myConstructorInfo = typeof(Object).GetConstructor(new Type[0]);
      myILGenerator3.Emit(OpCodes.Call, myConstructorInfo);
      myILGenerator3.Emit(OpCodes.Ldarg_0);
      myILGenerator3.Emit(OpCodes.Ldarg_1);
      myILGenerator3.Emit(OpCodes.Stfld, myGreetingField);
      myILGenerator3.Emit(OpCodes.Ret);
      // Add a method to the type.
      myMethodBuilder = myTypeBuilder.DefineMethod
         ("HelloWorld",MethodAttributes.Public,null,null);
      // Generate IL for the method.
      ILGenerator myILGenerator2 = myMethodBuilder.GetILGenerator();
      myILGenerator2.EmitWriteLine("Hello World from global");
      myILGenerator2.Emit(OpCodes.Ret);
      myModuleBuilder.CreateGlobalFunctions();
      myType1 = myTypeBuilder.CreateType();

      // Get the parameters of this constructor.
      ParameterInfo[] myParameterInfo = myConstructorBuilder.GetParameters();
      for(int i =0 ; i < myParameterInfo.Length; i++)
      {
         Console.WriteLine("Declaration type : " + myParameterInfo[i].Member.DeclaringType);
      }