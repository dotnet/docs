    class TestRegularExpressions
    {
        static void Main()
        {
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

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
    /* Output:
               C# code  (match for 'code' found)
               Chapter 2: Writing Code  (match for 'code' found)
               Unicode  (match for 'code' found)
               no match here
    */