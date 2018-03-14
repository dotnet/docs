// <Snippet5>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // Get the version of the executing assembly (that is, this assembly).
      Assembly assem = Assembly.GetEntryAssembly();
      AssemblyName assemName = assem.GetName();
      Version ver = assemName.Version;
      Console.WriteLine("Application {0}, Version {1}", assemName.Name, ver.ToString());
   }
}
// </Snippet5>
