// <Snippet3>
using System;
using System.Security;

public class Example
{
   public static void Main()
   {
      // Define the string value to be assigned to the secure string.
      string initString = "TestString";
      // Instantiate the secure string.
      SecureString testString = new SecureString();
      // Use the AppendChar method to add each char value to the secure string.
      foreach (char ch in initString)
         testString.AppendChar(ch);
         
      // Display secure string length.
      Console.WriteLine("The length of the string is {0} characters.", 
                        testString.Length);
      testString.Dispose();
   }
}
// The example displays the following output:
//      The length of the string is 10 characters.
// </Snippet3>
