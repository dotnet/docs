// <Snippet7>
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 2)]
unsafe struct ExampleStruct2
{

   public byte b1;
   public byte b2;
   public int i3;
   public fixed byte a4[1];
   public decimal d5;
}

public class Example
{
   public unsafe static void Main()
   {

      ExampleStruct2 ex = new ExampleStruct2();
      byte* addr = (byte*) &ex;
      Console.WriteLine("Size:      {0}", sizeof(ExampleStruct2));
      Console.WriteLine("b1 Offset: {0}", &ex.b1 - addr);
      Console.WriteLine("b2 Offset: {0}", &ex.b2 - addr);
      Console.WriteLine("i3 Offset: {0}", (byte*) &ex.i3 - addr);
      Console.WriteLine("a4 Offset: {0}", ex.a4 - addr);
      Console.WriteLine("d5 Offset: {0}", (byte*) &ex.d5 - addr);
   }
}
// The example displays the following output:
//       Size:      24
//       b1 Offset: 0
//       b2 Offset: 1
//       i3 Offset: 2
//       a4 Offset: 6
//       d5 Offset: 8
// </Snippet7>