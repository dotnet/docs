using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      String[] names = { "Samuel", "Dakota", "Koani", "Saya", "Vanya", "Jody",
                         "Yiska", "Yuma", "Jody", "Nikita" };
      var nameList = new List<String>();
      nameList.AddRange(names);
      Console.WriteLine("List in unsorted order: ");
      foreach (var name in nameList)
         Console.Write("   {0}", name);

      Console.WriteLine(Environment.NewLine);

      nameList.Sort();
      Console.WriteLine("List in sorted order: ");
      foreach (var name in nameList)
         Console.Write("   {0}", name);

      Console.WriteLine();

      // The example displays the following output:
      //    List in unsorted order:
      //       Samuel   Dakota   Koani   Saya   Vanya   Jody   Yiska   Yuma   Jody   Nikita
      //
      //    List in sorted order:
      //       Dakota   Jody   Jody   Koani   Nikita   Samuel   Saya   Vanya   Yiska   Yuma
      // </Snippet2>
   }
}
