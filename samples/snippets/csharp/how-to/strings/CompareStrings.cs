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
            string root = @"C:\users";
            string root2 = @"C:\Users";

            bool result = root.Equals(root2, StringComparison.Ordinal);

            Console.WriteLine($"Ordinal comparison: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");
            // </Snippet1>
        }

        private static void OrdinalIgnoreCase()
        {
            // <Snippet2>
            string root = @"C:\users";
            string root2 = @"C:\Users";

            bool result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"Ordinal ignore case: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");
            // </Snippet2>
        }

        private static void OrdinalStaticComparison()
        {
            // <Snippet3>
            string root = @"C:\users";
            string root2 = @"C:\Users";

            bool areEqual = String.Equals(root, root2, StringComparison.Ordinal);
            Console.WriteLine($"Ordinal static: <{root}> and <{root2}> are {(areEqual ? "equal." : "not equal.")}");
            areEqual = String.Equals(root, root2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"Ordinal static ignore case: <{root}> and <{root2}> are {(areEqual ? "equal." : "not equal.")}");
            // </Snippet3>
        }
        private static void ReferenceEqualAndInterning()
        {
            // <Snippet4>
            string a = "The computer ate my source code.";
            string b = "The computer ate my source code.";

            if (String.ReferenceEquals(a, b))
                Console.WriteLine("a and b are interned.");
            else
                Console.WriteLine("a and b are not interned.");

            string c = String.Copy(a);

            if (String.ReferenceEquals(a, c))
                Console.WriteLine("a and c are interned.");
            else
                Console.WriteLine("a and c are not interned.");
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
            Array.Sort(lines, StringComparer.Ordinal);

            string searchString = @"c:\public\TEXTFILE.TXT";
            Console.WriteLine($"Binary search for <{searchString}>");
            int result = Array.BinarySearch(lines, searchString, StringComparer.OrdinalIgnoreCase);
            ShowWhere<string>(lines, result);

            Console.WriteLine($"{(result > 0 ? "Found" : "Did not find")} {searchString}");

            void ShowWhere<T>(T[] array, int index)
            {
                if (index < 0)
                {
                    index = ~index;

                    Console.Write("Not found. Sorts between: ");

                    if (index == 0)
                        Console.Write("beginning of sequence and ");
                    else
                        Console.Write($"{array[index - 1]} and ");

                    if (index == array.Length)
                        Console.WriteLine("end of sequence.");
                    else
                        Console.WriteLine($"{array[index]}.");
                }
                else
                {
                    Console.WriteLine($"Found at index {index}.");
                }
            }
            //</snippet6>
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

            void ShowWhere<T>(IList<T> collection, int index)
            {
                if (index < 0)
                {
                    index = ~index;

                    Console.Write("Not found. Sorts between: ");

                    if (index == 0)
                        Console.Write("beginning of sequence and ");
                    else
                        Console.Write($"{collection[index - 1]} and ");

                    if (index == collection.Count)
                        Console.WriteLine("end of sequence.");
                    else
                        Console.WriteLine($"{collection[index]}.");
                }
                else
                {
                    Console.WriteLine($"Found at index {index}.");
                }
            }
            //</snippet8>
        }

        private static void CompareAcrossCultures()
        {
            //<snippet9>  
            string first = "Sie tanzen auf der Straße.";
            string second = "Sie tanzen auf der Strasse.";

            Console.WriteLine($"First sentence is <{first}>");
            Console.WriteLine($"Second sentence is <{second}>");

            var en = new System.Globalization.CultureInfo("en-US");

            // For culture-sensitive comparisons, use the String.Compare 
            // overload that takes a StringComparison value.
            int i = String.Compare(first, second, en, System.Globalization.CompareOptions.IgnoreNonSpace);
            Console.WriteLine($"Comparing in {en.Name} returns {i}.");

            var de = new System.Globalization.CultureInfo("de-DE");
            i = String.Compare(first, second, de, System.Globalization.CompareOptions.IgnoreNonSpace);
            Console.WriteLine($"Comparing in {de.Name} returns {i}.");

            bool b = String.Equals(first, second, StringComparison.CurrentCulture);
            Console.WriteLine($"The two strings {(b == true ? "are" : "are not")} equal.");
            //</snippet9>
        }
    }
}
