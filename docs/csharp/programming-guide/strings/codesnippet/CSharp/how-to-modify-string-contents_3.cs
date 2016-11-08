    class UnsafeString
    {
        unsafe static void Main(string[] args)
        {
            // Compiler will store (intern) 
            // these strings in same location.
            string s1 = "Hello";
            string s2 = "Hello";

            // Change one string using unsafe code.
            fixed (char* p = s1)
            {
                p[0] = 'C';
            }

            //  Both strings have changed.
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }