    class TestRegularExpressionValidation
    {
        static void Main()
        {
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

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
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