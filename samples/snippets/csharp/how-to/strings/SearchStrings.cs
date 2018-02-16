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
        }

        public static void SearchWithMethods()
        {
            // <Snippet1>
            string str = "Extension methods have all the capabilities of regular static methods.";

            // Write the string and include the quotation marks.
            System.Console.WriteLine("\"{0}\"", str);

            // Simple comparisons are always case sensitive!
            bool test1 = str.StartsWith("extension");
            System.Console.WriteLine("Starts with \"extension\"? {0}", test1);

            // For user input and strings that will be displayed to the end user, 
            // use the StringComparison parameter on methods that have it to specify how to match strings.
            bool test2 = str.StartsWith("extension", System.StringComparison.CurrentCultureIgnoreCase);
            System.Console.WriteLine("Starts with \"extension\"? {0} (ignoring case)", test2);

            bool test3 = str.EndsWith(".", System.StringComparison.CurrentCultureIgnoreCase);
            System.Console.WriteLine("Ends with '.'? {0}", test3);

            // This search returns the substring between two strings, so 
            // the first index is moved to the character just after the first string.
            int first = str.IndexOf("methods") + "methods".Length;
            int last = str.LastIndexOf("methods");
            string str2 = str.Substring(first, last - first);
            System.Console.WriteLine("Substring between \"methods\" and \"methods\": '{0}'", str2);

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
                System.Console.Write("{0,24}", s);

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    System.Console.WriteLine("  (match for '{0}' found)", sPattern);
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
                System.Console.Write("{0,14}", s);

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
