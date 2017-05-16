// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Nullable<int> n1 = new Nullable<int>(10);
      Nullable<int> n2 = null;
      Nullable<int> n3 = new Nullable<int>(20);
      n3 = null;
      Nullable<int>[] items = { n1, n2, n3 }; 

      foreach (var item in items) {
         Console.WriteLine("Has a value: {0}", item.HasValue);
         if (item.HasValue) {
            Console.WriteLine("Type: {0}", item.GetType().Name);
            Console.WriteLine("Value: {0}", item.Value);
         }
         else {
            Console.WriteLine("Null: {0}", item == null);
            Console.WriteLine("Default Value: {0}", item.GetValueOrDefault());
         }
         Console.WriteLine();
      }                  
   }
}
// The example displays the following output:
//       Has a value: True
//       Type: Int32
//       Value: 10
//       
//       Has a value: False
//       Null: True
//       Default Value: 0
//       
//       Has a value: False
//       Null: True
//       Default Value: 0
// </Snippet1>