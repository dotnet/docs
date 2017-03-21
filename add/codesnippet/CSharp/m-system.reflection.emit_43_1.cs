public class MyApplication
{
   public static void Main()
   {
      // Create the "HelloWorld" class
      TypeBuilder helloWorldClass = CreateCallee(Thread.GetDomain());
      Console.WriteLine("Full Name : " + helloWorldClass.FullName);
      Console.WriteLine("Constructors :");
      ConstructorInfo[] info =
         helloWorldClass.GetConstructors(BindingFlags.Public|BindingFlags.Instance);
      for(int index=0; index < info.Length; index++)
         Console.WriteLine(info[index].ToString());
   }

   // Create the callee transient dynamic assembly.
   private static TypeBuilder CreateCallee(AppDomain myDomain)
   {
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedAssembly";

      // Create the callee dynamic assembly.
      AssemblyBuilder myAssembly = myDomain.DefineDynamicAssembly(myAssemblyName,
         AssemblyBuilderAccess.Run);
      // Create a dynamic module named "CalleeModule" in the callee assembly.
      ModuleBuilder myModule = myAssembly.DefineDynamicModule("EmittedModule");

      // Define a public class named "HelloWorld" in the assembly.
      TypeBuilder helloWorldClass = myModule.DefineType("HelloWorld", TypeAttributes.Public);
      // Define a private String field named "Greeting" in the type.
      FieldBuilder greetingField = helloWorldClass.DefineField("Greeting", typeof(String),
         FieldAttributes.Private);

      // Create the constructor.
      ConstructorBuilder constructor = helloWorldClass.DefineTypeInitializer();

      // Generate IL for the method. The constructor calls its base class
      // constructor. The constructor stores its argument in the private field.
      ILGenerator constructorIL = constructor.GetILGenerator();
      constructorIL.Emit(OpCodes.Ldarg_0);
      ConstructorInfo superConstructor = typeof(Object).GetConstructor(new Type[0]);
      constructorIL.Emit(OpCodes.Call, superConstructor);
      constructorIL.Emit(OpCodes.Ldarg_0);
      constructorIL.Emit(OpCodes.Ldarg_1);
      constructorIL.Emit(OpCodes.Stfld, greetingField);
      constructorIL.Emit(OpCodes.Ret);

      helloWorldClass.CreateType();
      return(helloWorldClass);
   }
}