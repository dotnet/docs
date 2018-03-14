using System;

public class Sample
{
   public static void Main()
   {
   // <Snippet1>
   string str = "forty-two";
   char pad = '.';

   Console.WriteLine(str.PadRight(15, pad));    // Displays "forty-two......".
   Console.WriteLine(str.PadRight(2,  pad));    // Displays "forty-two".
   // </Snippet1>
   }
}
