// <Snippet2>
using System;
using System.Security;

public class Example
{
   public static void Main()
   {
      // Define the string value to assign to a new secure string.
      char[] chars = { 't', 'e', 's', 't' };
      // Instantiate the secure string.
      SecureString testString = new SecureString();
      // Assign the character array to the secure string.
      foreach (char ch in chars)
         testString.AppendChar(ch);      
      // Display secure string length.
      Console.WriteLine("The length of the string is {0} characters.", 
                        testString.Length);
      testString.Dispose();
   }
}
// The example displays the following output:
//      The length of the string is 4 characters.
// </Snippet2>
