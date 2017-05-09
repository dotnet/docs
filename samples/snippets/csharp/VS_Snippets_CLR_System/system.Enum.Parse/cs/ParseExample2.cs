
// <Snippet2>
using System;

[Flags] enum Colors { None=0, Red = 1, Green = 2, Blue = 4 };
   
public class Example
{
   public static void Main()
   {
      string[] colorStrings = { "0", "2", "8", "blue", "Blue", "Yellow", "Red, Green" };
      foreach (string colorString in colorStrings)
      {
         try {
            Colors colorValue = (Colors) Enum.Parse(typeof(Colors), colorString, true);        
            if (Enum.IsDefined(typeof(Colors), colorValue) | colorValue.ToString().Contains(","))  
               Console.WriteLine("Converted '{0}' to {1}.", colorString, colorValue.ToString());
            else
               Console.WriteLine("{0} is not an underlying value of the Colors enumeration.", colorString);
         }
         catch (ArgumentException) {
            Console.WriteLine("{0} is not a member of the Colors enumeration.", colorString);
         }
      }
   }
}
// The example displays the following output:
//       Converted '0' to None.
//       Converted '2' to Green.
//       8 is not an underlying value of the Colors enumeration.
//       Converted 'blue' to Blue.
//       Converted 'Blue' to Blue.
//       Yellow is not a member of the Colors enumeration.
//       Converted 'Red, Green' to Red, Green.
// </Snippet2>
