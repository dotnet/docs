// <Snippet1>
using System;
using System.Security;

public class Example
{
   unsafe public static void Main()
   {
      SecureString testString;
      // Define the string value to assign to a new secure string.
      char[] chars = { 't', 'e', 's', 't' };

      // Instantiate a new secure string.
      fixed(char* pChars = chars)
      {
         testString = new SecureString(pChars, chars.Length);
      }
      // Display secure string length.
      Console.WriteLine("The length of the string is {0} characters.", 
                        testString.Length);
      testString.Dispose();
   }
}
// The example displays the following output:
//      The length of the string is 4 characters.
// </Snippet1>
