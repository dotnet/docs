// <Snippet1>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // Instantiate a target object.
      Int32 integer1 = 1632;
      // Instantiate an Assembly class to the assembly housing the Integer type.
      Assembly systemAssembly = integer1.GetType().Assembly;
      // Get the location of the assembly using the file: protocol.
      Console.WriteLine("CodeBase = {0}", systemAssembly.CodeBase);
   }
}
// The example displays output like the following:
//    CodeBase = file:///C:/Windows/Microsoft.NET/Framework64/v4.0.30319/mscorlib.dll
// </Snippet1>