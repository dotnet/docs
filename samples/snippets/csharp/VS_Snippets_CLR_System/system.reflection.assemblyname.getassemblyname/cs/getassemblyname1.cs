// <Snippet1>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      Console.WriteLine(AssemblyName.GetAssemblyName(@".\UtilityLibrary.dll"));
   }
}
// The example displays output like the following:
//   UtilityLibrary, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// </Snippet1>
