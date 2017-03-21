         // Define a dynamic module in "TempAssembly" assembly.
         ModuleBuilder myModuleBuilder = myAssemblyBuilder.
                                       DefineDynamicModule("TempModule");
         // Define a runtime class with specified name and attributes.
         TypeBuilder myTypeBuilder = myModuleBuilder.DefineType
                                    ("TempClass",TypeAttributes.Public);
         Type[] paramArray = {typeof(Array)};
         // Add 'SortArray' method to the class, with the given signature.
         MethodBuilder myMethod = myTypeBuilder.DefineMethod("SortArray", 
                                   MethodAttributes.Public,typeof(Array),paramArray);

         Type[] myArrayClass = new Type[1];
         Type[] parameterTypes = {typeof(Array)};
         // Get the 'MethodInfo' object corresponding to 'Sort' method of 'Array' class.
         MethodInfo myMethodInfo=myModuleBuilder.GetArrayMethod(
                     myArrayClass.GetType(),"Sort",CallingConventions.Standard,
                                                                                  null,parameterTypes);
         // Get the token corresponding to 'Sort' method of 'Array' class.
         MethodToken myMethodToken=myModuleBuilder.GetArrayMethodToken(
                     myArrayClass.GetType(),"Sort",CallingConventions.Standard,
                                                                                 null,parameterTypes);
         Console.WriteLine("Token used by module to identify the 'Sort' method"
                                     + " of 'Array' class is : {0:x} ",myMethodToken.Token);

         ILGenerator methodIL = myMethod.GetILGenerator();
         methodIL.Emit(OpCodes.Ldarg_1);
         methodIL.Emit(OpCodes.Call,myMethodInfo);
         methodIL.Emit(OpCodes.Ldarg_1);
         methodIL.Emit(OpCodes.Ret);

         // Complete the creation of type.
         myTypeBuilder.CreateType();