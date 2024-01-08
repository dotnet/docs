// <Snippet3>
using System;
using System.Reflection;

public class Example5
{
   public static void Main()
   {
      // Get the version of a specific assembly.
      string filename = @".\StringLibrary.dll";
      Assembly assem = Assembly.ReflectionOnlyLoadFrom(filename);
      AssemblyName assemName = assem.GetName();
      Version ver = assemName.Version;
      Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString());
   }
}
// </Snippet3>
