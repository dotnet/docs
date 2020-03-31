// <Snippet7>
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class RegexUtilities
{
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                var domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}
// </Snippet7>

// <Snippet8>
class Program
{
    static void Main(string[] args)
    {
        string[] emailAddresses = { "david.jones@proseware.com", "d.j@server1.proseware.com",
                                    "jones@ms1.proseware.com", "j.@server1.proseware.com",
                                    "j@proseware.com9", "js#internal@proseware.com",
                                    "j_9@[129.126.118.1]", "j..s@proseware.com",
                                    "js*@proseware.com", "js@proseware..com",
                                    "js@proseware.com9", "j.s@server1.proseware.com",
                                    "\"j\\\"s\\\"\"@proseware.com", "js@contoso.中国" };

        foreach (var emailAddress in emailAddresses)
        {
            if (RegexUtilities.IsValidEmail(emailAddress))
                Console.WriteLine($"Valid:   {emailAddress}");
            else
                Console.WriteLine($"Invalid: {emailAddress}");
        }

        Console.ReadKey();
    }
}
// The example displays the following output:
//       Valid: david.jones@proseware.com
//       Valid: d.j@server1.proseware.com
//       Valid: jones@ms1.proseware.com
//       Invalid: j.@server1.proseware.com
//       Valid: j@proseware.com9
//       Valid: js#internal@proseware.com
//       Valid: j_9@[129.126.118.1]
//       Invalid: j..s@proseware.com
//       Invalid: js*@proseware.com
//       Invalid: js@proseware..com
//       Valid: js@proseware.com9
//       Valid: j.s@server1.proseware.com
//       Valid: "j\"s\""@proseware.com
//       Valid: js@contoso.中国
// </Snippet8>