            static void Main()
            {
                int i = 2, j = 3;
                System.Console.WriteLine("i = {0}  j = {1}" , i, j);

                SwapByRef (ref i, ref j);

                System.Console.WriteLine("i = {0}  j = {1}" , i, j);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
            /* Output:
                i = 2  j = 3
                i = 3  j = 2
            */