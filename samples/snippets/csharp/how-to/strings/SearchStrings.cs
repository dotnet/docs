using System;
using System.Collections.Generic;
using System.Text;

namespace HowToStrings
{
    public class SearchStrings
    {
        public static void Examples()
        {
            SearchWithMethods();
            RegularExpressionsOne();
            RegularExpressionsValidation();
        }

        public static void SearchWithMethods()
        {
            // <Snippet1>
            string factMessage = "Extension methods have all the capabilities of regular static methods.";

            // Write the string and include the quotation marks.
            System.Console.WriteLine($"\"{factMessage}\"");

            // Simple comparisons are always case sensitive!
            bool startsWithSearchResult = factMessage.StartsWith("extension");
            System.Console.WriteLine($"Starts with \"extension\"? {startsWithSearchResult}");

            // For user input and strings that will be displayed to the end user, 
            // use the StringComparison parameter on methods that have it to specify how to match strings.
            bool ignoreCaseSearchResult = factMessage.StartsWith("extension", System.StringComparison.CurrentCultureIgnoreCase);
            System.Console.WriteLine($"Starts with \"extension\"? {ignoreCaseSearchResult} (ignoring case)");

            bool endsWithSearchResult = factMessage.EndsWith(".", System.StringComparison.CurrentCultureIgnoreCase);
            System.Console.WriteLine($"Ends with '.'? {endsWithSearchResult}");

            // This search returns the substring between two strings, so 
            // the first index is moved to the character just after the first string.
            int first = factMessage.IndexOf("methods") + "methods".Length;
            int last = factMessage.LastIndexOf("methods");
            string str2 = factMessage.Substring(first, last - first);
            System.Console.WriteLine($"Substring between \"methods\" and \"methods\": '{str2}'");

            /*
                Output:
                "Extension methods have all the capabilities of regular static methods."
                Starts with "extension"? False
                Starts with "extension"? True (ignoring case)
                Ends with '.'? True
                Substring between "methods" and "methods": ' have all the capabilities of regular static '
                Press any key to exit.     
            */
            // </Snippet1>
        }

        public static void RegularExpressionsOne()
        {
            // <Snippet2>
            string[] sentences =
            {
                "C# code",
                "Chapter 2: Writing Code",
                "Unicode",
                "no match here"
            };

            string sPattern = "code";

            foreach (string s in sentences)
            {
                System.Console.Write($"{s,24}");

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    System.Console.WriteLine($"  (match for '{sPattern}' found)");
                }
                else
                {
                    System.Console.WriteLine();
                }
            }

            /* Output:
               C# code  (match for 'code' found)
               Chapter 2: Writing Code  (match for 'code' found)
               Unicode  (match for 'code' found)
               no match here
            */
            // </Snippet2>
        }

        public static void RegularExpressionsValidation()
        {
            // <Snippet3>
            string[] numbers =
            {
                "123-555-0190",
                "444-234-22450",
                "690-555-0178",
                "146-893-232",
                "146-555-0122",
                "4007-555-0111",
                "407-555-0111",
                "407-2-5555",
            };

            string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";

            foreach (string s in numbers)
            {
                System.Console.Write($"{s,14}");

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
                {
                    System.Console.WriteLine(" - valid");
                }
                else
                {
                    System.Console.WriteLine(" - invalid");
                }
            }

            /* Output:
                  123-555-0190 - valid
                 444-234-22450 - invalid
                  690-555-0178 - valid
                   146-893-232 - invalid
                  146-555-0122 - valid
                 4007-555-0111 - invalid
                  407-555-0111 - valid
                    407-2-5555 - invalid
            */
            // </Snippet3>
        }
    }
}
