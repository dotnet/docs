// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
       // Define a byte array.
       byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
       Console.WriteLine("The byte array: ");
       Console.WriteLine("   {0}\n", BitConverter.ToString(bytes));
       
       // Convert the array to a base 64 sring.
       String s = Convert.ToBase64String(bytes);
       Console.WriteLine("The base 64 string:\n   {0}\n", s);
       
       // Restore the byte array.
       byte[] newBytes = Convert.FromBase64String(s);
       Console.WriteLine("The restored byte array: ");
       Console.WriteLine("   {0}\n", BitConverter.ToString(newBytes));
   }
}
// The example displays the following output:
//     The byte array:
//        02-04-06-08-0A-0C-0E-10-12-14
//     
//     The base 64 string:
//        AgQGCAoMDhASFA==
//     
//     The restored byte array:
//        02-04-06-08-0A-0C-0E-10-12-14
// </Snippet1>

