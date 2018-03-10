using System;
using System.Collections.Generic;
using System.Text;

namespace HowToStrings
{
    public static class CompareStrings
    {
        public static void Examples()
        {
            OrdinalEquality();
            OrdinalIgnoreCase();
            OrdinalStaticComparison();
            ReferenceEqualAndInterning();

            SortArrayOfStrings();
            SearchSortedArray();

            SortListOfStrings();
            SearchSortedList();

            CompareAcrossCultures();
        }

        private static void OrdinalEquality()
        {
            // <Snippet1>
            // Internal strings that will never be localized.
            string root = @"C:\users";
            string root2 = @"C:\Users";

            // Use the overload of the Equals method that specifies a StringComparison.
            // Ordinal is the fastest way to compare two strings.
            bool result = root.Equals(root2, StringComparison.Ordinal);

            Console.WriteLine($"Ordinal comparison: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");
            // Ordinal comparison: C:\users and C:\Users are not equal.
            // </Snippet1>
        }

        private static void OrdinalIgnoreCase()
        {
            // <Snippet2>
            // Internal strings that will never be localized.
            string root = @"C:\users";
            string root2 = @"C:\Users";

            // To ignore case means "user" equals "User". This is the same as using
            // String.ToUpperInvariant on each string and then performing an ordinal comparison.
            bool result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"Ordinal ignore case: {root} and {root2} are {(result ? "equal." : "not equal.")}");
            // Ordinal ignore case: C:\users and C:\Users are equal.
            // </Snippet2>
        }

        private static void OrdinalStaticComparison()
        {
            // <Snippet3>
            // Internal strings that will never be localized.
            string root = @"C:\users";
            string root2 = @"C:\Users";


            // A static method is also available.
            bool areEqual = String.Equals(root, root2, StringComparison.Ordinal);
            Console.WriteLine($"Ordinal static: {root} and {root2} are {(areEqual ? "equal." : "not equal.")}");
            areEqual = String.Equals(root, root2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"Ordinal staticignore case: {root} and {root2} are {(areEqual ? "equal." : "not equal.")}");
            // </Snippet3>
        }
        private static void ReferenceEqualAndInterning()
        {
            // <Snippet4>
            // String interning. Are these really two distinct objects?
            string a = "The computer ate my source code.";
            string b = "The computer ate my source code.";

            // ReferenceEquals returns true if both objects
            // point to the same location in memory.
            if (String.ReferenceEquals(a, b))
                Console.WriteLine("a and b are interned.");
            else
                Console.WriteLine("a and b are not interned.");

            // Use String.Copy method to avoid interning.
            string c = String.Copy(a);

            if (String.ReferenceEquals(a, c))
                Console.WriteLine("a and c are interned.");
            else
                Console.WriteLine("a and c are not interned.");
            // a and b are interned.
            // a and c are not interned.
            // </Snippet4>
        }

        private static void SortArrayOfStrings()
        {
            // <Snippet5>
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
                Console.WriteLine($"   {s}");
            }

            Console.WriteLine("\n\rSorted order:");

            // Specify Ordinal to demonstrate the different behavior.
            Array.Sort(lines, StringComparer.Ordinal);

            foreach (string s in lines)
            {
                Console.WriteLine($"   {s}");
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
             */
            // </Snippet5>
        }

        private static void SearchSortedArray()
        {
            // <Snippet6>
            string[] lines = new string[]
            {
                @"c:\public\textfile.txt",
                @"c:\public\textFile.TXT",
                @"c:\public\Text.txt",
                @"c:\public\testfile2.txt"
            };
            // Specify Ordinal to demonstrate the different behavior.
            Array.Sort(lines, StringComparer.Ordinal);

            string searchString = @"c:\public\TEXTFILE.TXT";
            Console.WriteLine($"Binary search for <{searchString}>");
            int result = Array.BinarySearch(lines, searchString, StringComparer.OrdinalIgnoreCase);
            ShowWhere<string>(lines, result);

            Console.WriteLine($"{(result > 0 ? "Found" : "Did not find")} {searchString}");

            // Displays where the string was found, or, if not found,
            // where it would have been located.
            void ShowWhere<T>(T[] array, int index)
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
                        Console.Write($"{array[index - 1]} and ");

                    if (index == array.Length)
                        Console.WriteLine("end of array.");
                    else
                        Console.WriteLine($"{array[index]}.");
                }
                else
                {
                    Console.WriteLine($"Found at index {index}.");
                }
                /*
                 * Output:
                    Binary search for c:\public\TEXTFILE.TXT
                    Found at index 2.
                 */
                //</snippet6>
            }
        }

        private static void SortListOfStrings()
        {
            // <Snippet7>
            List<string> lines = new List<string>
            {
                @"c:\public\textfile.txt",
                @"c:\public\textFile.TXT",
                @"c:\public\Text.txt",
                @"c:\public\testfile2.txt"
            };

            Console.WriteLine("Non-sorted order:");
            foreach (string s in lines)
            {
                Console.WriteLine($"   {s}");
            }

            Console.WriteLine("\n\rSorted order:");

            lines.Sort((left, right) => left.CompareTo(right));
            foreach (string s in lines)
            {
                Console.WriteLine($"   {s}");
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
             */
            // </Snippet7>
        }

        private static void SearchSortedList()
        {
            // <Snippet8>
            List<string> lines = new List<string>
            {
                @"c:\public\textfile.txt",
                @"c:\public\textFile.TXT",
                @"c:\public\Text.txt",
                @"c:\public\testfile2.txt"
            };
            lines.Sort((left, right) => left.CompareTo(right));
 
            string searchString = @"c:\public\TEXTFILE.TXT";
            Console.WriteLine($"Binary search for <{searchString}>");
            int result = lines.BinarySearch(searchString, null);
            ShowWhere<string>(lines, result);

            Console.WriteLine($"{(result > 0 ? "Found" : "Did not find")} {searchString}");


            // Displays where the string was found, or, if not found,
            // where it would have been located.
            void ShowWhere<T>(IList<T> collection, int index)
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
                        Console.Write($"{collection[index - 1]} and ");

                    if (index == collection.Count)
                        Console.WriteLine("end of array.");
                    else
                        Console.WriteLine($"{collection[index]}.");
                }
                else
                {
                    Console.WriteLine($"Found at index {index}.");
                }
                /*
                 * Output:
                    Binary search for c:\public\TEXTFILE.TXT
                    Found at index 2.
                 */
                //</snippet6>
            }
        }

        private static void CompareAcrossCultures()
        {
            //<snippet9>  
            // "They dance in the street."
            // Linguistically (in Windows), "ss" is equal to 
            // the German essetz: 'ß' character in both en-US and de-DE cultures.
            string first = "Sie tanzen auf der Straße.";
            string second = "Sie tanzen auf der Strasse.";

            Console.WriteLine($"First sentence is <{first}>");
            Console.WriteLine($"Second sentence is <{second}>");

            // Store CultureInfo for the current culture. Note that the original culture
            // can be set and retrieved on the current thread object.
            System.Threading.Thread thread = System.Threading.Thread.CurrentThread;
            System.Globalization.CultureInfo originalCulture = thread.CurrentCulture;

            // Set the culture to en-US.
            thread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            // For culture-sensitive comparisons, use the String.Compare 
            // overload that takes a StringComparison value.
            int i = String.Compare(first, second, StringComparison.CurrentCulture);
            Console.WriteLine($"Comparing in {originalCulture.Name} returns {i}.");

            // Change the current culture to Deutsch-Deutschland.
            thread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
            i = String.Compare(first, second, StringComparison.CurrentCulture);
            Console.WriteLine($"Comparing in {thread.CurrentCulture.Name} returns {i}.");

            // For culture-sensitive string equality, use either StringCompare as above
            // or the String.Equals overload that takes a StringComparison value.
            thread.CurrentCulture = originalCulture;
            bool b = String.Equals(first, second, StringComparison.CurrentCulture);
            Console.WriteLine($"The two strings {(b == true ? "are" : "are not")} equal.");

            /*
             * Output:
                First sentence is Sie tanzen auf der Straße.
                Second sentence is Sie tanzen auf der Strasse.
                Comparing in en-US returns 0.
                Comparing in de-DE returns 0.
                The two strings are equal.
             */
            //</snippet9>
        }
    }
}
