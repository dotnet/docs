// <Snippet5>
using System;

[assembly: CLSCompliant(true)]

public class ArrayHelper
{
   unsafe public static Array CreateInstance(Type type, int* ptr, int items)
   {
      Array arr = Array.CreateInstance(type, items);
      int* addr = ptr;
      for (int ctr = 0; ctr < items; ctr++) {
          int value = *addr;
          arr.SetValue(value, ctr);
          addr++;
      }
      return arr;
   }
}
// The attempt to compile this example displays the following output:
//    UnmanagedPtr1.cs(8,57): warning CS3001: Argument type 'int*' is not CLS-compliant
// </Snippet5>

public class Example
{
   public static void Main()
   {
      int[] numbers = {3, 6, 9, 12 };
      int[] numbers2;
      unsafe {
         fixed(int* ptr = numbers) {
            numbers2 = (int[]) ArrayHelper.CreateInstance(typeof(int), ptr, numbers.Length);
         }
      }
      foreach (var number2 in numbers2)
         Console.WriteLine(number2);
   }
}