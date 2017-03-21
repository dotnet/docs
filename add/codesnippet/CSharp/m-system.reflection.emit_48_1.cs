         // Get the current AppDomain.
         AppDomain myAppDomain = AppDomain.CurrentDomain;
         AssemblyName myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "SampleAssembly";

         // Create a dynamic assembly 'myAssembly' with access mode 'Run'.
         AssemblyBuilder myAssembly = myAppDomain.DefineDynamicAssembly(
                                 myAssemblyName, AssemblyBuilderAccess.Run);
         // Create a dynamic module 'myModule' in 'myAssembly'.
         ModuleBuilder myModule=myAssembly.DefineDynamicModule("MyDynamicModule",true);
         // Define a public class 'MyDynamicClass'.
         TypeBuilder myTypeBuilder = myModule.DefineType("MyDynamicClass",
                                          TypeAttributes.Public);
         // Define a public string field.
         FieldBuilder myField = myTypeBuilder.DefineField("MyDynamicField", 
                                  typeof(String), FieldAttributes.Public);
         // Create the constructor.
         Type[] myConstructorArgs = {typeof(String)};
         ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
            MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);

         // Generate IL for 'myConstructor'.
         ILGenerator myConstructorIL = myConstructor.GetILGenerator();
         // Emit the necessary opcodes.
         myConstructorIL.Emit(OpCodes.Ldarg_0);
         ConstructorInfo mySuperConstructor = typeof(Object).GetConstructor(new Type[0]);
         myConstructorIL.Emit(OpCodes.Call, mySuperConstructor);
         myConstructorIL.Emit(OpCodes.Ldarg_0);
         myConstructorIL.Emit(OpCodes.Ldarg_1);
         myConstructorIL.Emit(OpCodes.Stfld, myField);
         myConstructorIL.Emit(OpCodes.Ret);

         // Define a dynamic method named 'MyDynamicMethod'.
         MethodBuilder myMethod = myTypeBuilder.DefineMethod("MyDynamicMethod",
            MethodAttributes.Public, typeof(String), null);
         // Generate IL for 'myMethod'.
         ILGenerator myMethodIL = myMethod.GetILGenerator();

         // Begin the scope for a local variable.
         myMethodIL.BeginScope();

         LocalBuilder myLocalBuilder = myMethodIL.DeclareLocal(typeof(int));
         Console.WriteLine("\nTrying to access the local variable within the scope.");
         Console.WriteLine("'myLocalBuilder' type is: {0}", myLocalBuilder.LocalType);
         myMethodIL.Emit(OpCodes.Ldstr, "Local value");
         myMethodIL.Emit(OpCodes.Stloc_0, myLocalBuilder);
         
         // End the scope of 'myLocalBuilder'.
         myMethodIL.EndScope();

         // Access the local variable outside the scope.
         Console.WriteLine("\nTrying to access the local variable outside the scope:");
         myMethodIL.Emit(OpCodes.Stloc_0, myLocalBuilder);
         myMethodIL.Emit(OpCodes.Ldloc_0 );
         myMethodIL.Emit(OpCodes.Ret );

         // Create 'MyDynamicClass' class.
         Type myType1 = myTypeBuilder.CreateType();