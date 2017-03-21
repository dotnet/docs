using System;

public class Example
{
   public static void Main()
   {
      String s = "This is a string.";
      String sub1 = "this";
      Console.WriteLine("Does '{0}' contain '{1}'?", s, sub1);
      StringComparison comp = StringComparison.Ordinal;
      Console.WriteLine("   {0:G}: {1}", comp, s.Contains(sub1, comp));
      
      comp = StringComparison.OrdinalIgnoreCase;
      Console.WriteLine("   {0:G}: {1}", comp, s.Contains(sub1, comp));
   }
}
// The example displays the following output:
//       Does 'This is a string.' contain 'this'?
//          Ordinal: False
//          OrdinalIgnoreCase: True