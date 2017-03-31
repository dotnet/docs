// <Snippet3>
using System;
using System.Text.RegularExpressions;

public class RegexUtilities
{
   public static bool IsValidEmail(string strIn)
   {
       // Return true if strIn is in valid e-mail format.
       return Regex.IsMatch(strIn, 
              @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + 
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"); 
   }
}
// </Snippet3>

// <Snippet4>
public class Application
{
   public static void Main()
   {
      string[] emailAddresses = { "david.jones@proseware.com", "d.j@server1.proseware.com", 
                                  "jones@ms1.proseware.com", "j.@server1.proseware.com", 
                                  "j@proseware.com9", "js#internal@proseware.com", 
                                  "j_9@[129.126.118.1]", "j..s@proseware.com", 
                                  "js*@proseware.com", "js@proseware..com", 
                                  "js@proseware.com9", "j.s@server1.proseware.com" };
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
//       Valid: js#internal@proseware.com
//       Valid: j_9@[129.126.118.1]
//       Invalid: j..s@proseware.com
//       Invalid: js*@proseware.com
//       Invalid: js@proseware..com
//       Invalid: js@proseware.com9
//       Valid: j.s@server1.proseware.com
// </Snippet4>
