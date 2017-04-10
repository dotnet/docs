// <Snippet2>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      String fullName = "sysglobl, Version=4.0.0.0, Culture=neutral, " +
                        "PublicKeyToken=b03f5f7f11d50a3a, processor architecture=MSIL";
      var an = new AssemblyName(fullName);
      var assem = Assembly.Load(an);
      Console.WriteLine("Public types in assembly {0}:", assem.FullName);
      foreach (var t in assem.GetTypes())
         if (t.IsPublic)
            Console.WriteLine("   {0}", t.FullName);
   }
}
// The example displays the following output:
//   Public types in assembly sysglobl, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a:
//      System.Globalization.CultureAndRegionInfoBuilder
//      System.Globalization.CultureAndRegionModifiers
// </Snippet2>

