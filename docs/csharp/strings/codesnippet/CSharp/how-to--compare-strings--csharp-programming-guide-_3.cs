    class SortStringArrays
    {
        static void Main()
        {
            
            string[] lines = new string[]
            {
                @"c:\public\textfile.txt",
                @"c:\public\textFile.TXT",
                @"c:\public\Text.txt",
                @"c:\public\testfile2.txt"
            };

            Console.WriteLine("Non-sorted order:");
            foreach (string s in lines)
            {
                Console.WriteLine("   {0}", s);
            }

            Console.WriteLine("\n\rSorted order:");

            // Specify Ordinal to demonstrate the different behavior.
            Array.Sort(lines, StringComparer.Ordinal);

            foreach (string s in lines)
            {
                Console.WriteLine("   {0}", s);
            }
           

            string searchString = @"c:\public\TEXTFILE.TXT";
            Console.WriteLine("Binary search for {0}", searchString);
            int result = Array.BinarySearch(lines, searchString, StringComparer.OrdinalIgnoreCase);
            ShowWhere<string>(lines, result);

            //Console.WriteLine("{0} {1}", result > 0 ? "Found" : "Did not find", searchString);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        // Displays where the string was found, or, if not found,
        // where it would have been located.
        private static void ShowWhere<T>(T[] array, int index)
        {
            if (index < 0)
            {
                // If the index is negative, it represents the bitwise
                // complement of the next larger element in the array.
                index = ~index;

                Console.Write("Not found. Sorts between: ");

                if (index == 0)
                    Console.Write("beginning of array and ");
                else
                    Console.Write("{0} and ", array[index - 1]);

                if (index == array.Length)
                    Console.WriteLine("end of array.");
                else
                    Console.WriteLine("{0}.", array[index]);
            }
            else
            {
                Console.WriteLine("Found at index {0}.", index);
            }
        }


    }
    /*
     * Output:
        Non-sorted order:
           c:\public\textfile.txt
           c:\public\textFile.TXT
           c:\public\Text.txt
           c:\public\testfile2.txt

        Sorted order:
           c:\public\Text.txt
           c:\public\testfile2.txt
           c:\public\textFile.TXT
           c:\public\textfile.txt
        Binary search for c:\public\TEXTFILE.TXT
        Found at index 2.
     */
