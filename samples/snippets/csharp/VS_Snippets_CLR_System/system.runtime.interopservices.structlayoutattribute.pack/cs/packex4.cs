// <Snippet5>
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack=8)]
struct ExampleStruct
{
   public byte b1;
   public byte b2;
   public int i3;
}

public class Example
{
   public unsafe static void Main()
   {

      ExampleStruct ex = new ExampleStruct();
      byte* addr = (byte*) &ex;
      Console.WriteLine("Size:      {0}", sizeof(ExampleStruct));
      Console.WriteLine("b1 Offset: {0}", &ex.b1 - addr);
      Console.WriteLine("b2 Offset: {0}", &ex.b2 - addr);
      Console.WriteLine("i3 Offset: {0}", (byte*) &ex.i3 - addr);
   }
}
// The example displays the following output:
//       Size:      8
//       b1 Offset: 0
//       b2 Offset: 1
//       i3 Offset: 4
// </Snippet5>