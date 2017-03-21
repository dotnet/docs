      MethodBuilder myMethodBuilder=null;

      AppDomain myCurrentDomain = AppDomain.CurrentDomain;
      // Create assembly in current CurrentDomain
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "TempAssembly";
      // Create a dynamic assembly
      myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly
         (myAssemblyName, AssemblyBuilderAccess.RunAndSave);
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule");
      FieldInfo myFieldInfo =
         myModuleBuilder.DefineUninitializedData("myField",2,FieldAttributes.Public);
      // Create a type in the module
      TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("TempClass",TypeAttributes.Public);
      FieldBuilder myGreetingField = myTypeBuilder.DefineField("Greeting",
         typeof(String), FieldAttributes.Public);
      Type[] myConstructorArgs = { typeof(String) };
      // Define a constructor of the dynamic class.
      ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
         MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);
      PermissionSet myPset = new PermissionSet(PermissionState.Unrestricted);
      // Add declarative security to the constructor.
      Console.WriteLine("Adding declarative security to the constructor.....");
      Console.WriteLine("The Security action to be taken is \"DENY\" and" +
         " Permission set is \"UNRESTRICTED\".");
      myConstructor.AddDeclarativeSecurity(SecurityAction.Deny,myPset);
      MethodAttributes myMethodAttributes = myConstructor.Attributes;
      Type myAttributeType = typeof(MethodAttributes);
      int myAttribValue = (int) myMethodAttributes;
      if(! myAttributeType.IsEnum)
      {
         Console.WriteLine("This is not an Enum");
      }
      FieldInfo[] myFieldInfo1 = myAttributeType.GetFields(BindingFlags.Public | BindingFlags.Static);
      Console.WriteLine("The Field info names of the Attributes for the constructor are:");
      for (int i = 0; i < myFieldInfo1.Length; i++)
      {
         int myFieldValue = (Int32)myFieldInfo1[i].GetValue(null);
         if ((myFieldValue & myAttribValue) == myFieldValue)
         {
            Console.WriteLine("   " + myFieldInfo1[i].Name);
         }
      }

      Type myType2 = myConstructor.DeclaringType;
      Console.WriteLine("The declaring type is : "+myType2.ToString());
      ParameterBuilder myParameterBuilder1 =
         myConstructor.DefineParameter(1,  ParameterAttributes.Out, "My Parameter Name1");
      Console.WriteLine("The name of the parameter is : " +
         myParameterBuilder1.Name);
      if(myParameterBuilder1.IsIn)
         Console.WriteLine(myParameterBuilder1.Name +" is Input parameter.");
      else
         Console.WriteLine(myParameterBuilder1.Name +" is not Input Parameter.");
      ParameterBuilder myParameterBuilder2 =
         myConstructor.DefineParameter(1, ParameterAttributes.In, "My Parameter Name2");
      Console.WriteLine("The Parameter name is : " +
         myParameterBuilder2.Name);
      if(myParameterBuilder2.IsIn)
         Console.WriteLine(myParameterBuilder2.Name +" is Input parameter.");
      else
         Console.WriteLine(myParameterBuilder2.Name + " is not Input Parameter.");