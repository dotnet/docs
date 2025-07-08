// <Snippet14>
using System;

public struct BoolStruct
{
   public bool flag1;
   public bool flag2;
   public bool flag3;
   public bool flag4;
   public bool flag5;
}

public class Example9
{
   public static void Main()
   {
      unsafe {
         BoolStruct b = new BoolStruct();
         bool* addr = (bool*) &b;
         Console.WriteLine($"Size of BoolStruct: {sizeof(BoolStruct)}");
         Console.WriteLine("Field offsets:");
         Console.WriteLine($"   flag1: {(bool*) &b.flag1 - addr}");
         Console.WriteLine($"   flag1: {(bool*) &b.flag2 - addr}");
         Console.WriteLine($"   flag1: {(bool*) &b.flag3 - addr}");
         Console.WriteLine($"   flag1: {(bool*) &b.flag4 - addr}");
         Console.WriteLine($"   flag1: {(bool*) &b.flag5 - addr}");
      }
   }
}
// The example displays the following output:
//       Size of BoolStruct: 5
//       Field offsets:
//          flag1: 0
//          flag1: 1
//          flag1: 2
//          flag1: 3
//          flag1: 4
// </Snippet14>
