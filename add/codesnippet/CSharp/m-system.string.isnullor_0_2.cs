using System;

public class Example
{
   public static void Main()
   {
      String s = null;
      
      Console.WriteLine("The value of the string is '{0}'", s);

      try {
         Console.WriteLine("String length is {0}", s.Length);
      }
      catch (NullReferenceException e) {
         Console.WriteLine(e.Message);
      }
   }
}
// The example displays the following output:
//     The value of the string is ''
//     Object reference not set to an instance of an object.