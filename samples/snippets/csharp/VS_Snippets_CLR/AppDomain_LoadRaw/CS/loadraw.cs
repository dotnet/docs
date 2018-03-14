// <Snippet1>
using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

class Test {
   public static void Main() {
      AppDomain currentDomain = AppDomain.CurrentDomain;
      
      InstantiateMyType(currentDomain);   // Failed!

      currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);
      
      InstantiateMyType(currentDomain);   // OK!
   }
   
   static void InstantiateMyType(AppDomain domain) {
      try {
	 // You must supply a valid fully qualified assembly name here.
         domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyType");
      } catch (Exception e) {
         Console.WriteLine(e.Message);
      }
   }
   
   // Loads the content of a file to a byte array. 
   static byte[] loadFile(string filename) {
      FileStream fs = new FileStream(filename, FileMode.Open);
      byte[] buffer = new byte[(int) fs.Length];
      fs.Read(buffer, 0, buffer.Length);
      fs.Close();
   
      return buffer;
   }   

   static Assembly MyResolver(object sender, ResolveEventArgs args) {
      AppDomain domain = (AppDomain) sender;

      // Once the files are generated, this call is
      // actually no longer necessary.
      EmitAssembly(domain);
      
      byte[] rawAssembly = loadFile("temp.dll");
      byte[] rawSymbolStore = loadFile("temp.pdb");
      Assembly assembly = domain.Load(rawAssembly, rawSymbolStore);

      return assembly;
   }
   
   // Creates a dynamic assembly with symbol information
   // and saves them to temp.dll and temp.pdb
   static void EmitAssembly(AppDomain domain) {
      AssemblyName assemblyName = new AssemblyName();
      assemblyName.Name = "MyAssembly";

      AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
      ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule", "temp.dll", true);
      TypeBuilder typeBuilder = moduleBuilder.DefineType("MyType", TypeAttributes.Public);

      ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null);
      ILGenerator ilGenerator = constructorBuilder.GetILGenerator();
      ilGenerator.EmitWriteLine("MyType instantiated!");
      ilGenerator.Emit(OpCodes.Ret);

      typeBuilder.CreateType();
      
      assemblyBuilder.Save("temp.dll");
   }
}
// </Snippet1>