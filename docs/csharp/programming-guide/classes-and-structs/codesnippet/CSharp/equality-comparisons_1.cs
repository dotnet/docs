        using System;
        class Test
        {
            public int Num { get; set; }
            public string Str { get; set; }

            static void Main()
            {
                Test a = new Test() { Num = 1, Str = "Hi" };
                Test b = new Test() { Num = 1, Str = "Hi" };

                bool areEqual = System.Object.ReferenceEquals(a, b);
                // False:
                System.Console.WriteLine("ReferenceEquals(a, b) = {0}", areEqual);

                // Assign b to a.
                b = a;

                // Repeat calls with different results.
                areEqual = System.Object.ReferenceEquals(a, b);
                // True:
                System.Console.WriteLine("ReferenceEquals(a, b) = {0}", areEqual);

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }