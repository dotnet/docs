// <Snippet1>
using System;

public class Class1 { }
public class DerivedC1 : Class1 { }

class IsSubclassTest
{
   public static void Main()
   {
      Console.WriteLine("DerivedC1 subclass of Class1: {0}",
                         typeof(DerivedC1).IsSubclassOf(typeof(Class1)));
   }
}
// The example displays the following output:
//        DerivedC1 subclass of Class1: True
// </Snippet1>