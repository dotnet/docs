        static void Main(string[] args)
        {
            int numVal = -1;
            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine("Enter a number between −2,147,483,648 and +2,147,483,647 (inclusive).");

                string input = Console.ReadLine();

                // ToInt32 can throw FormatException or OverflowException.
                try
                {
                    numVal = Convert.ToInt32(input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("The number cannot fit in an Int32.");
                }
                finally
                {
                    if (numVal < Int32.MaxValue)
                    {
                        Console.WriteLine("The new value is {0}", numVal + 1);
                    }
                    else
                    {
                        Console.WriteLine("numVal cannot be incremented beyond its current value");
                    }
                }
                Console.WriteLine("Go again? Y/N");
                string go = Console.ReadLine();
                if (go == "Y" || go == "y")
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            }
            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();    
        }
        // Sample Output:
        // Enter a number between -2,147,483,648 and +2,147,483,647 (inclusive).
        // 473
        // The new value is 474
        // Go again? Y/N
        // y
        // Enter a number between -2,147,483,648 and +2,147,483,647 (inclusive).
        // 2147483647
        // numVal cannot be incremented beyond its current value
        // Go again? Y/N
        // Y
        // Enter a number between -2,147,483,648 and +2,147,483,647 (inclusive).
        // -1000
        // The new value is -999
        // Go again? Y/N
        // n
        // Press any key to exit.