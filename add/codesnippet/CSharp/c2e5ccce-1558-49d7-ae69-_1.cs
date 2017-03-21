            /// <summary>
            /// This IComparer class sorts by the fractional part of the decimal number.
            /// </summary>
            public class SpecialComparer : IComparer<decimal>
            {
                /// <summary>
                /// Compare two decimal numbers by their fractional parts.
                /// </summary>
                /// <param name="d1">The first decimal to compare.</param>
                /// <param name="d2">The second decimal to compare.</param>
                /// <returns>1 if the first decimal's fractional part 
                /// is greater than the second decimal's fractional part,
                /// -1 if the first decimal's fractional
                /// part is less than the second decimal's fractional part,
                /// or the result of calling Decimal.Compare()
                /// if the fractional parts are equal.</returns>
                public int Compare(decimal d1, decimal d2)
                {
                    decimal fractional1, fractional2;

                    // Get the fractional part of the first number.
                    try
                    {
                        fractional1 = decimal.Remainder(d1, decimal.Floor(d1));
                    }
                    catch (DivideByZeroException)
                    {
                        fractional1 = d1;
                    }
                    // Get the fractional part of the second number.
                    try
                    {
                        fractional2 = decimal.Remainder(d2, decimal.Floor(d2));
                    }
                    catch (DivideByZeroException)
                    {
                        fractional2 = d2;
                    }

                    if (fractional1 == fractional2)
                        return Decimal.Compare(d1, d2);
                    else if (fractional1 > fractional2)
                        return 1;
                    else
                        return -1;
                }
            }

            public static void OrderByDescendingEx1()
            {
                List<decimal> decimals =
                    new List<decimal> { 6.2m, 8.3m, 0.5m, 1.3m, 6.3m, 9.7m };

                // Sort the decimal values in descending order
                // by using a custom comparer.
                IEnumerable<decimal> query =
                    decimals.AsQueryable()
                    .OrderByDescending(num => num, new SpecialComparer());

                foreach (decimal num in query)
                    Console.WriteLine(num);
            }

            /*
                This code produces the following output:

                9.7
                0.5
                8.3
                6.3
                1.3
                6.2
            */
