// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string input = "4.0";
      ParseVersion(input);
      
      input = "4.0.";
      ParseVersion(input);
      
      input = "1.1.2";
      ParseVersion(input);
      
      input = "1.1.2.01702";
      ParseVersion(input);
      
      input = "1.1.2.0702.119";
      ParseVersion(input);
      
      input =  "1.3.5.2150000000";
      ParseVersion(input);
   }
   
   private static void ParseVersion(string input)
   {
      Version ver = null;
      if (Version.TryParse(input, out ver))
         Console.WriteLine("Converted '{0} to {1}.", input, ver);
      else
         Console.WriteLine("Unable to determine the version from '{0}'.",
                           input);
   }
}
// The example displays the following output:
//       Converted '4.0 to 4.0.
//       Unable to determine the version from '4.0.'.
//       Converted '1.1.2 to 1.1.2.
//       Converted '1.1.2.01702 to 1.1.2.1702.
//       Unable to determine the version from '1.1.2.0702.119'.
//       Unable to determine the version from '1.3.5.2150000000'.
// </Snippet1>