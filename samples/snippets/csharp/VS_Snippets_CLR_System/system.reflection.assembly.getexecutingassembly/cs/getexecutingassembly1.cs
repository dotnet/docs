// <Snippet5>
using System;
using System.Reflection;

class Example
{
   static void Main()
   {
      // Get the assembly from a known type in that assembly.
      Type t = typeof(Example);
      Assembly assemFromType = t.Assembly;
      Console.WriteLine("Assembly that contains Example:");
      Console.WriteLine("   {0}\n", assemFromType.FullName);

      // Get the currently executing assembly.
      Assembly currentAssem = Assembly.GetExecutingAssembly();
      Console.WriteLine("Currently executing assembly:");
      Console.WriteLine("   {0}\n", currentAssem.FullName);
      
      Console.WriteLine("The two Assembly objects are equal: {0}",
                        assemFromType.Equals(currentAssem));
   }
}
// The example displays the following output:
//    Assembly that contains Example:
//       GetExecutingAssembly1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
//
//    Currently executing assembly:
//       GetExecutingAssembly1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
//
//    The two Assembly objects are equal: True
// </Snippet5>
