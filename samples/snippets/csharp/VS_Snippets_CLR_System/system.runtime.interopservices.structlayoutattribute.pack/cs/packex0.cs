// <Snippet1>
using System;

struct ExampleStruct
{
   public byte b1;
   public byte b2;
   public int i3;
}
// </Snippet1>

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
