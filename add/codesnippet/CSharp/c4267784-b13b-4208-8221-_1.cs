   public static void Main() 
   {
      AssemblyBuilder myAssembly;
      IResourceWriter myResourceWriter; 
      myAssembly = (AssemblyBuilder)CreateAssembly(Thread.GetDomain()).Assembly;
         
      myResourceWriter = myAssembly.DefineResource("myResourceFile",
         "A sample Resource File", "MyEmitAssembly.MyResource.resources");
      myResourceWriter.AddResource("AddResource 1", "First added resource");
      myResourceWriter.AddResource("AddResource 2", "Second added resource");
      myResourceWriter.AddResource("AddResource 3", "Third added resource");

      myAssembly.DefineVersionInfoResource("AssemblySample", "2:0:0:1",
         "Microsoft Corporation", "@Copyright Microsoft Corp. 1990-2001",
         ".NET is a trademark of Microsoft Corporation");
      myAssembly.Save("MyEmitAssembly.dll");
   }

   // Create the callee transient dynamic assembly.
   private static Type CreateAssembly(AppDomain appDomain) 
   {
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "MyEmitAssembly";
      AssemblyBuilder myAssembly = appDomain.DefineDynamicAssembly(myAssemblyName, 
         AssemblyBuilderAccess.Save);
      ModuleBuilder myModule = myAssembly.DefineDynamicModule("EmittedModule",
         "EmittedModule.mod");

      // Define a public class named "HelloWorld" in the assembly.
      TypeBuilder helloWorldClass = 
         myModule.DefineType("HelloWorld", TypeAttributes.Public);
      // Define the Display method.
      MethodBuilder myMethod = helloWorldClass.DefineMethod("Display", 
         MethodAttributes.Public, typeof(String), null);

      // Generate IL for GetGreeting.
      ILGenerator methodIL = myMethod.GetILGenerator();
      methodIL.Emit(OpCodes.Ldstr, "Display method get called.");
      methodIL.Emit(OpCodes.Ret);

      // Returns the type HelloWorld.
      return(helloWorldClass.CreateType());
   }   