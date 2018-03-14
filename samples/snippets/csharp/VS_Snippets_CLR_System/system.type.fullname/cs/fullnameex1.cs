// <Snippet2>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      Type t = typeof(List<>);
      Console.WriteLine(t.FullName);
      Console.WriteLine();

      List<String> list = new List<String>();
      t = list.GetType();
      Console.WriteLine(t.FullName);
   }
}
// The example displays the following output:
// System.Collections.Generic.List`1
//
// System.Collections.Generic.List`1[[System.String, mscorlib,
//        Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
// </Snippet2>
