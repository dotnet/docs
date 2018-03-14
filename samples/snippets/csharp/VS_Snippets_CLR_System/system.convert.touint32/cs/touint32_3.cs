using System;

// <Snippet16>
public class Example
{
   public static void Main()
   {
      string[] hexStrings = { "80000000", "0FFFFFFF", "F0000000", "00A3000", "D", 
                              "-13", "9AC61", "GAD", "FFFFFFFFFF" };
      
      foreach (string hexString in hexStrings)
      {
         Console.Write("{0,-12}  -->  ", hexString);
         try {
            uint number = Convert.ToUInt32(hexString, 16);
            Console.WriteLine("{0,18:N0}", number);
         }
         catch (FormatException) {
            Console.WriteLine("{0,18}", "Bad Format");
         }   
         catch (OverflowException)
         {
            Console.WriteLine("{0,18}", "Numeric Overflow");
         }   
         catch (ArgumentException) {
            Console.WriteLine("{0,18}", "Invalid in Base 16");
         }
      }                                            
   }
}
// The example displays the following output:
//       80000000      -->       2,147,483,648
//       0FFFFFFF      -->         268,435,455
//       F0000000      -->       4,026,531,840
//       00A3000       -->             667,648
//       D             -->                  13
//       -13           -->  Invalid in Base 16
//       9AC61         -->             633,953
//       GAD           -->          Bad Format
//       FFFFFFFFFF    -->    Numeric Overflow
// </Snippet16>
