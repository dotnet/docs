using System;

public class Example13
{
   public static void Main()
   {
      // <Snippet6>
      byte[] byteValues = { 12, 163, 255 };
      foreach (byte byteValue in byteValues)
         Console.WriteLine(byteValue.ToString("X4"));
      // The example displays the following output:
      //       000C
      //       00A3
      //       00FF
      // </Snippet6>
   }
}
