// <Snippet1>
using System;
using System.Reflection;

class Test {

   public static void Main() {
      AppDomain currentDomain = AppDomain.CurrentDomain;
      currentDomain.AssemblyLoad += new AssemblyLoadEventHandler(MyAssemblyLoadEventHandler);
      
      PrintLoadedAssemblies(currentDomain);
      // Lists mscorlib and this assembly

      // You must supply a valid fully qualified assembly name here.      
      currentDomain.CreateInstance("System.Windows.Forms, Version, Culture, PublicKeyToken", "System.Windows.Forms.TextBox");
      // Loads System, System.Drawing, System.Windows.Forms
      
      PrintLoadedAssemblies(currentDomain);
      // Lists all five assemblies
   }
   
   static void PrintLoadedAssemblies(AppDomain domain) {
      Console.WriteLine("LOADED ASSEMBLIES:");
      foreach (Assembly a in domain.GetAssemblies()) {
         Console.WriteLine(a.FullName);
      }
      Console.WriteLine();
   }
   
   static void MyAssemblyLoadEventHandler(object sender, AssemblyLoadEventArgs args) {
      Console.WriteLine("ASSEMBLY LOADED: " + args.LoadedAssembly.FullName);
      Console.WriteLine();
   }
}
// </Snippet1>