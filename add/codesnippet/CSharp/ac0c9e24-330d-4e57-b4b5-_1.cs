         MethodBuilder myMethodBuilder = null;
         AppDomain myCurrentDomain = AppDomain.CurrentDomain;
         // Create assembly in current CurrentDomain.
         AssemblyName myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "TempAssembly";
         // Create a dynamic assembly.
         myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly
            (myAssemblyName, AssemblyBuilderAccess.Run);
         // Create a dynamic module in the assembly.
         myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule", true);
         FieldInfo myFieldInfo2 =
            myModuleBuilder.DefineUninitializedData("myField", 2, FieldAttributes.Public);
         // Create a type in the module.
         TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("TempClass",TypeAttributes.Public);
         FieldBuilder myGreetingField = myTypeBuilder.DefineField("Greeting", 
            typeof(String), FieldAttributes.Public);
         Type[] myConstructorArgs = { typeof(String) };
         // Define a constructor of the dynamic class.
         ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
            MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);
         // Set the method implementation flags for the constructor.
         myConstructor.SetImplementationFlags(MethodImplAttributes.PreserveSig | MethodImplAttributes.Runtime);
         // Get the method implementation flags for the constructor.
         MethodImplAttributes myMethodAttributes = myConstructor.GetMethodImplementationFlags();
         Type myAttributeType = typeof(MethodImplAttributes);
         int myAttribValue = (int) myMethodAttributes;
         if(! myAttributeType.IsEnum)
         {
            Console.WriteLine("This is not an Enum");
         }
         // Display the field info names of the retrieved method implementation flags.
         FieldInfo[] myFieldInfo = myAttributeType.GetFields(BindingFlags.Public | BindingFlags.Static);
         Console.WriteLine("The Field info names of the MethodImplAttributes for the constructor are:");
         for (int i = 0; i < myFieldInfo.Length; i++)
         {
            int myFieldValue = (Int32)myFieldInfo[i].GetValue(null);
            if ((myFieldValue & myAttribValue) == myFieldValue)
            {
               Console.WriteLine("   " + myFieldInfo[i].Name);
            }
         }