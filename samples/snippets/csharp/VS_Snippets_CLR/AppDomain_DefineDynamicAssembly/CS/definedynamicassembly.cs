// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

class Test {
   public static void Main() {
      AppDomain currentDomain = AppDomain.CurrentDomain;

      InstantiateMyDynamicType(currentDomain);   // Failed!
      
      currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
      
      InstantiateMyDynamicType(currentDomain);   // OK!
   }

   static void InstantiateMyDynamicType(AppDomain domain) {
      try {
         // You must supply a valid fully qualified assembly name here. 
         domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyDynamicType");
      } catch (Exception e) {
         Console.WriteLine(e.Message);
      }
   }   

   static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args) {
      return DefineDynamicAssembly((AppDomain) sender);
   }
   
   static Assembly DefineDynamicAssembly(AppDomain domain) {
      // Build a dynamic assembly using Reflection Emit API.
   
      AssemblyName assemblyName = new AssemblyName();
      assemblyName.Name = "MyDynamicAssembly";

      AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
      ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MyDynamicModule");
      TypeBuilder typeBuilder = moduleBuilder.DefineType("MyDynamicType", TypeAttributes.Public);
      ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null);
      ILGenerator ilGenerator = constructorBuilder.GetILGenerator();
      
      ilGenerator.EmitWriteLine("MyDynamicType instantiated!");
      ilGenerator.Emit(OpCodes.Ret);

      typeBuilder.CreateType();

      return assemblyBuilder;
   }
}
// </Snippet1>
