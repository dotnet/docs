// <Snippet4>
using System;
using System.Reflection;

public class Example3
{
   public static void Main()
   {
      // Get the version of the current assembly.
      Assembly assem = typeof(Example).Assembly;
      AssemblyName assemName = assem.GetName();
      Version ver = assemName.Version;
      Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString());
   }
}
// </Snippet4>
