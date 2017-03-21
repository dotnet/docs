      MethodBuilder myMethodBuilder = null;
      AppDomain myCurrentDomain = AppDomain.CurrentDomain;
      // Create assembly in current CurrentDomain.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "TempAssembly";
      // Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly
               (myAssemblyName, AssemblyBuilderAccess.Run);
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule",true);
      FieldInfo myFieldInfo =
         myModuleBuilder.DefineUninitializedData("myField", 2, FieldAttributes.Public);
      // Create a type in the module.
      TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("TempClass",TypeAttributes.Public);
      FieldBuilder myGreetingField = myTypeBuilder.DefineField("Greeting", 
                                          typeof(String), FieldAttributes.Public);
      Type[] myConstructorArgs = { typeof(String) };
      // Define a constructor of the dynamic class.
      ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
      MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);
      // Display the name of the constructor.
      Console.WriteLine("The constructor name is  : "+ myConstructor.Name);
      myConstructor.SetSymCustomAttribute("MySimAttribute", new byte[]{01,00,00});