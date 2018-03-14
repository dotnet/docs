// <Snippet6>
using System;
using System.Reflection;

[assembly:AssemblyVersionAttribute("2.0.1")]

public class Example1
{
   public static void Main()
   {
      Assembly thisAssem = typeof(Example1).Assembly;
      AssemblyName thisAssemName = thisAssem.GetName();
       
      Version ver = thisAssemName.Version;
       
      Console.WriteLine("This is version {0} of {1}.", ver, thisAssemName.Name);    
   }
}
// The example displays the following output:
//        This is version 2.0.1.0 of Example1.
// </Snippet6>
