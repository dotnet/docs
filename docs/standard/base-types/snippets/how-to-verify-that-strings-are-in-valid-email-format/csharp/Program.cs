using System;

namespace RegexExamples
{
    // <TestRegex>
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

        }
    }
    // This example displays the following output:
    // Valid:   david.jones@proseware.com
    // Valid:   d.j@server1.proseware.com
    // Valid:   jones@ms1.proseware.com
    // Valid:   j.@server1.proseware.com
    // Valid:   j@proseware.com9
    // Valid:   js#internal@proseware.com
    // Valid:   j_9@[129.126.118.1]
    // Valid:   j..s@proseware.com
    // Valid:   js*@proseware.com
    // Invalid: js@proseware..com
    // Valid:   js@proseware.com9
    // Valid:   j.s@server1.proseware.com
    // Valid:   "j\"s\""@proseware.com
    // Valid:   js@contoso.??
    // </TestRegex>
}
