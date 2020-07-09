// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class RegexUtilities
{
   public static bool IsValidEmail(string strIn)
   {
       // Return true if strIn is in valid email format.
       return Regex.IsMatch(strIn,
                    @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
   }
}
// </Snippet1>

// <Snippet2>
public class Application
{
   public static void Main()
   {
      string[] emailAddresses = { "david.jones@proseware.com", "d.j@server1.proseware.com",
                                  "jones@ms1.proseware.com", "j.@server1.proseware.com",
                                  "j@proseware.com9" };
      foreach (string emailAddress in emailAddresses)
      {
         if (RegexUtilities.IsValidEmail(emailAddress))
            Console.WriteLine("Valid: {0}", emailAddress);
         else
            Console.WriteLine("Invalid: {0}", emailAddress);
      }
   }
}
// The example displays the following output:
//       Valid: david.jones@proseware.com
//       Valid: d.j@server1.proseware.com
//       Valid: jones@ms1.proseware.com
//       Invalid: j.@server1.proseware.com
//       Invalid: j@proseware.com9
// </Snippet2>
