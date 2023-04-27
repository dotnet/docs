using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HowToStrings
{
    public static class CompareStrings
    {
        public static void Examples()
        {
            OrdinalDefaultComparisons();
            OrdinalIgnoreCaseComparisons();
            WordSortOrderInvariantCulture();
            LinguisticComparisons();

            SortArrayOfStrings();
            SearchSortedArray();

            SortListOfStrings();
            SearchSortedList();

            ReferenceEqualAndInterning();
        }

        private static void OrdinalDefaultComparisons()
        {
            // <Snippet1>
            string root = @"C:\users";
            string root2 = @"C:\Users";

            bool result = root.Equals(root2);
            Console.WriteLine($"Ordinal comparison: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");

            result = root.Equals(root2, StringComparison.Ordinal);
            Console.WriteLine($"Ordinal comparison: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");

            Console.WriteLine($"Using == says that <{root}> and <{root2}> are {(root == root2 ? "equal" : "not equal")}");
            // </Snippet1>
        }

        private static void OrdinalIgnoreCaseComparisons()
        {
            // <Snippet2>
            string root = @"C:\users";
            string root2 = @"C:\Users";

            bool result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
            bool areEqual = String.Equals(root, root2, StringComparison.OrdinalIgnoreCase);
            int comparison = String.Compare(root, root2, comparisonType: StringComparison.OrdinalIgnoreCase);

            Console.WriteLine($"Ordinal ignore case: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");
            Console.WriteLine($"Ordinal static ignore case: <{root}> and <{root2}> are {(areEqual ? "equal." : "not equal.")}");
            if (comparison < 0)
                Console.WriteLine($"<{root}> is less than <{root2}>");
            else if (comparison > 0)
                Console.WriteLine($"<{root}> is greater than <{root2}>");
            else
                Console.WriteLine($"<{root}> and <{root2}> are equivalent in order");
            // </Snippet2>
        }

        private static void WordSortOrderInvariantCulture()
        {
            //<snippet3>
            string first = "Sie tanzen auf der Straße.";
            string second = "Sie tanzen auf der Strasse.";

            Console.WriteLine($"First sentence is <{first}>");
            Console.WriteLine($"Second sentence is <{second}>");

            bool equal = String.Equals(first, second, StringComparison.InvariantCulture);
            Console.WriteLine($"The two strings {(equal == true ? "are" : "are not")} equal.");
            showComparison(first, second);

            string word = "coop";
            string words = "co-op";
            string other = "cop";

            showComparison(word, words);
            showComparison(word, other);
            showComparison(words, other);
            void showComparison(string one, string two)
            {
                int compareLinguistic = String.Compare(one, two, StringComparison.InvariantCulture);
                int compareOrdinal = String.Compare(one, two, StringComparison.Ordinal);
                if (compareLinguistic < 0)
                    Console.WriteLine($"<{one}> is less than <{two}> using invariant culture");
                else if (compareLinguistic > 0)
                    Console.WriteLine($"<{one}> is greater than <{two}> using invariant culture");
                else
                    Console.WriteLine($"<{one}> and <{two}> are equivalent in order using invariant culture");
                if (compareOrdinal < 0)
                    Console.WriteLine($"<{one}> is less than <{two}> using ordinal comparison");
                else if (compareOrdinal > 0)
                    Console.WriteLine($"<{one}> is greater than <{two}> using ordinal comparison");
                else
                    Console.WriteLine($"<{one}> and <{two}> are equivalent in order using ordinal comparison");
            }
            //</snippet3>
        }
        private static void LinguisticComparisons()
        {
            //<snippet4>
            string first = "Sie tanzen auf der Straße.";
            string second = "Sie tanzen auf der Strasse.";

            Console.WriteLine($"First sentence is <{first}>");
            Console.WriteLine($"Second sentence is <{second}>");

            var en = new System.Globalization.CultureInfo("en-US");

            // For culture-sensitive comparisons, use the String.Compare
            // overload that takes a StringComparison value.
            int i = String.Compare(first, second, en, System.Globalization.CompareOptions.None);
            Console.WriteLine($"Comparing in {en.Name} returns {i}.");

            var de = new System.Globalization.CultureInfo("de-DE");
            i = String.Compare(first, second, de, System.Globalization.CompareOptions.None);
            Console.WriteLine($"Comparing in {de.Name} returns {i}.");

            bool b = String.Equals(first, second, StringComparison.CurrentCulture);
            Console.WriteLine($"The two strings {(b ? "are" : "are not")} equal.");

            string word = "coop";
            string words = "co-op";
            string other = "cop";

            showComparison(word, words, en);
            showComparison(word, other, en);
            showComparison(words, other, en);
            void showComparison(string one, string two, System.Globalization.CultureInfo culture)
            {
                int compareLinguistic = String.Compare(one, two, en, System.Globalization.CompareOptions.None);
                int compareOrdinal = String.Compare(one, two, StringComparison.Ordinal);
                if (compareLinguistic < 0)
                    Console.WriteLine($"<{one}> is less than <{two}> using en-US culture");
                else if (compareLinguistic > 0)
                    Console.WriteLine($"<{one}> is greater than <{two}> using en-US culture");
                else
                    Console.WriteLine($"<{one}> and <{two}> are equivalent in order using en-US culture");
                if (compareOrdinal < 0)
                    Console.WriteLine($"<{one}> is less than <{two}> using ordinal comparison");
                else if (compareOrdinal > 0)
                    Console.WriteLine($"<{one}> is greater than <{two}> using ordinal comparison");
                else
                    Console.WriteLine($"<{one}> and <{two}> are equivalent in order using ordinal comparison");
            }
            //</snippet4>
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
            Array.Sort(lines, StringComparer.CurrentCulture);

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
            Array.Sort(lines, StringComparer.CurrentCulture);

            string searchString = @"c:\public\TEXTFILE.TXT";
            Console.WriteLine($"Binary search for <{searchString}>");
            int result = Array.BinarySearch(lines, searchString, StringComparer.CurrentCulture);
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
            int result = lines.BinarySearch(searchString);
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
    }
}
