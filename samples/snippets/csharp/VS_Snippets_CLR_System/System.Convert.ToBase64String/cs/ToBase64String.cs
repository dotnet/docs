// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      // Define an array of 20 elements and display it.
      int[] arr = new int[20]; 
      int value = 1;
      for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++) {
         arr[ctr] = value;
         value = value * 2 + 1;
      }
      DisplayArray(arr);

      // Convert the array of integers to a byte array.
      byte[] bytes = new byte[arr.Length * 4];
      for (int ctr = 0; ctr < arr.Length; ctr++) {
         Array.Copy(BitConverter.GetBytes(arr[ctr]), 0, 
                    bytes, ctr * 4, 4);
      }
         
      // Encode the byte array using Base64 encoding
      String base64 = Convert.ToBase64String(bytes);
      Console.WriteLine("The encoded string: ");
      for (int ctr = 0; ctr <= base64.Length / 50; ctr++) 
         Console.WriteLine(base64.Substring(ctr * 50, 
                                            ctr * 50 + 50 <= base64.Length 
                                               ? 50 : base64.Length - ctr * 50));
      Console.WriteLine();
      
      // Convert the string back to a byte array.
      byte[] newBytes = Convert.FromBase64String(base64);

      // Convert the byte array back to an integer array.
      int[] newArr = new int[newBytes.Length/4];
      for (int ctr = 0; ctr < newBytes.Length / 4; ctr ++)
         newArr[ctr] = BitConverter.ToInt32(newBytes, ctr * 4);
         
      DisplayArray(newArr);
   }

   private static void DisplayArray(Array arr)
   {
      Console.WriteLine("The array:");
      Console.Write("{ ");
      for (int ctr = 0; ctr < arr.GetUpperBound(0); ctr++) {
         Console.Write("{0}, ", arr.GetValue(ctr));
         if ((ctr + 1) % 10 == 0) 
            Console.Write("\n  ");
      }
      Console.WriteLine("{0} {1}", arr.GetValue(arr.GetUpperBound(0)), "}");
      Console.WriteLine();
   }
}
// The example displays the following output:
// The array:
// { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023,
//   2047, 4095, 8191, 16383, 32767, 65535, 131071, 262143, 524287, 1048575 }
// 
// The encoded string:
// AQAAAAMAAAAHAAAADwAAAB8AAAA/AAAAfwAAAP8AAAD/AQAA/w
// MAAP8HAAD/DwAA/x8AAP8/AAD/fwAA//8AAP//AQD//wMA//8H
// 
// The array:
// { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023,
//   2047, 4095, 8191, 16383, 32767, 65535, 131071, 262143, 524287, 1048575 }
// </Snippet2>

