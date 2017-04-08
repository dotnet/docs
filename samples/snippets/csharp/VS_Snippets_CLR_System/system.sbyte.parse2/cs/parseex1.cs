using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      // Define an array of numeric strings.
      string[] values = { "-16", "  -3", "+ 12", " +12 ", "  12  ",
                          "+120", "(103)", "192", "-160" };
                                 
      // Parse each string and display the result.
      foreach (string value in values)
      {
         try {
            Console.WriteLine("Converted '{0}' to the SByte value {1}.",
                              value, SByte.Parse(value));
         }
         catch (FormatException) {
            Console.WriteLine("'{0}' cannot be parsed successfully by SByte type.",
                              value);
         }                              
         catch (OverflowException) {
            Console.WriteLine("'{0}' is out of range of the SByte type.",
                              value);
         }                                                                        
      }
      // The example displays the following output:
      //       Converted '-16' to the SByte value -16.
      //       Converted '  -3' to the SByte value -3.
      //       '+ 12' cannot be parsed successfully by SByte type.
      //       Converted ' +12 ' to the SByte value 12.
      //       Converted '  12  ' to the SByte value 12.
      //       Converted '+120' to the SByte value 120.
      //       '(103)' cannot be parsed successfully by SByte type.
      //       '192' is out of range of the SByte type.
      //       '-160' is out of range of the SByte type.
      // </Snippet1>
   }
}
