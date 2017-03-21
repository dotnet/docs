            public class CaseInsensitiveComparer : IComparer<string>
            {
                public int Compare(string x, string y)
                {
                    return string.Compare(x, y, true);
                }
            }

            public static void ThenByDescendingEx1()
            {
                string[] fruits = 
                { "apPLe", "baNanA", "apple", "APple", "orange", "BAnana", "ORANGE", "apPLE" };

                // Sort the strings first ascending by their length and 
                // then descending using a custom case insensitive comparer.
                IEnumerable<string> query =
                    fruits.AsQueryable()
                    .OrderBy(fruit => fruit.Length)
                    .ThenByDescending(fruit => fruit, new CaseInsensitiveComparer());

                foreach (string fruit in query)
                    Console.WriteLine(fruit);
            }

            /*
                This code produces the following output:
            
                apPLe
                apple
                APple
                apPLE
                orange
                ORANGE
                baNanA
                BAnana
            */
