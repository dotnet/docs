// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      var tuple1Double = Tuple.Create(3.456e-18);
      DisplayTuple(tuple1Double);
      
      var tuple1String = Tuple.Create("Australia");
      DisplayTuple(tuple1String);
      
      var tuple1Bool = Tuple.Create(true);
      DisplayTuple(tuple1Bool);
      
      var tuple1Char = Tuple.Create('a');
      DisplayTuple(tuple1Char);
   }

   private static void DisplayTuple(object obj)
   {
      Console.WriteLine(obj.ToString());
   }
}
// The example displays the following output:
//       (3.456E-18)
//       (Australia)
//       (True)
//       (a)
// </Snippet1>