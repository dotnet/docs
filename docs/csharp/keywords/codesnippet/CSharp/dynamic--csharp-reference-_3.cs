        static void convertToDynamic()
        {
            dynamic d;
            int i = 20;
            d = (dynamic)i;
            Console.WriteLine(d);

            string s = "Example string.";
            d = (dynamic)s;
            Console.WriteLine(d);

            DateTime dt = DateTime.Today;
            d = (dynamic)dt;
            Console.WriteLine(d);

        }
        // Results:
        // 20
        // Example string.
        // 2/17/2009 9:12:00 AM