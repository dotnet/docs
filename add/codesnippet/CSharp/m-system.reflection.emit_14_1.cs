         AppDomain currentDomain;
         AssemblyName myAssemblyName;
         MethodBuilder myMethodBuilder=null;
         ILGenerator myILGenerator;

         // Get the current application domain for the current thread.
         currentDomain = AppDomain.CurrentDomain;
         myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "TempAssembly";
         
         // Define a dynamic assembly in the 'currentDomain'.
         myAssemblyBuilder = 
            currentDomain.DefineDynamicAssembly
                        (myAssemblyName, AssemblyBuilderAccess.RunAndSave);
         // Define a dynamic module in "TempAssembly" assembly.
         myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule");

         // Define a global method in the 'TempModule' module.
         myMethodBuilder = myModuleBuilder.DefineGlobalMethod
              ("MyMethod1",MethodAttributes.Static|MethodAttributes.Public,
                    null,null);
         myILGenerator = myMethodBuilder.GetILGenerator();
         myILGenerator.EmitWriteLine("Hello World from global method.");
         myILGenerator.Emit(OpCodes.Ret);
         // Fix up the 'TempModule' module .
         myModuleBuilder.CreateGlobalFunctions();