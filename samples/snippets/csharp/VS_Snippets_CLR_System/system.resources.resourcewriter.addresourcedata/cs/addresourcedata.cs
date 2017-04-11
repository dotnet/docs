// <Snippet1>
using System;
using System.Collections;
using System.Resources;

public class Example
{
   public static void Main()
   {
      ResourceWriter rw = new ResourceWriter(@".\TypeResources.resources");
      int n1 = 1032;
      rw.AddResourceData("Integer1", "ResourceTypeCode.Int32", BitConverter.GetBytes(n1));
      int n2 = 2064;       
      rw.AddResourceData("Integer2", "ResourceTypeCode.Int32", BitConverter.GetBytes(n2));
      rw.Generate();
      rw.Close();

      ResourceReader rr = new ResourceReader(@".\TypeResources.resources");
      IDictionaryEnumerator e = rr.GetEnumerator();
      while (e.MoveNext())
         Console.WriteLine("{0}: {1}", e.Key, e.Value);
   }
}
// The example displays the following output:
//       Integer2: 2064
//       Integer1: 1032
// </Snippet1>      
      