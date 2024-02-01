using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      // <Snippet6>
      int[] values = { 1, 2, 4, 8, 16, 32, 64, 128 };
      Console.WriteLine(values.ToString());

      List<int> list = new List<int>(values);
      Console.WriteLine(list.ToString());

      // The example displays the following output:
      //       System.Int32[]
      //       System.Collections.Generic.List`1[System.Int32]
      // </Snippet6>
   }
}
