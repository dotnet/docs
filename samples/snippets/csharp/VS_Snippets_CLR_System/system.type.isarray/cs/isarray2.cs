// <Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      Type[] types = { typeof(String), typeof(int[]),
                       typeof(ArrayList), typeof(Array),
                       typeof(List<String>),
                       typeof(IEnumerable<Char>) };
      foreach (var t in types)
         Console.WriteLine("{0,-15} IsArray = {1}", t.Name + ":",
                           t.IsArray);
   }
}
// The example displays the following output:
//       String:         IsArray = False
//       Int32[]:        IsArray = True
//       ArrayList:      IsArray = False
//       Array:          IsArray = False
//       List`1:         IsArray = False
//       IEnumerable`1:  IsArray = False
// </Snippet1>
