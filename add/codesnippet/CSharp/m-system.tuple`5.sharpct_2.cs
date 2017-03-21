            var tuple5 = new Tuple<string, int, int, int, int>
                                  ("New York", 1990, 7322564, 2000, 8008278);
            Console.WriteLine("{0}: {1:N0} in {2}, {3:N0} in {4}",
                              tuple5.Item1, tuple5.Item3, tuple5.Item2,
                              tuple5.Item5, tuple5.Item4);
            // Displays New York: 7,322,564 in 1990, 8,008,278 in 2000