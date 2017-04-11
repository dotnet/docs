using System;

namespace TupleCreateC
{
    class Create1
    {
        static void Main(string[] args)
        {
            Create1Tuple();
            New1Tuple();
            Create2Tuple();
            New2Tuple();
            Create3Tuple();
            New3Tuple();
            Create4Tuple();
            New4Tuple();
            Create5Tuple();
            New5Tuple();
            Create6Tuple();
            New6Tuple();
            Create7Tuple();
            New7Tuple();
            //Create8Tuple();
            //New8Tuple();
            CreateNTuple();
            NewNTuple();
            Example();
        }

        private static void Create1Tuple()
        {
            // <Snippet1>
            var tuple1 = Tuple.Create(12);
            Console.WriteLine(tuple1.Item1);     // Displays 12
            // </Snippet1>
        }

        private static void New1Tuple()
        {
            // <Snippet2>
            var tuple1 = new Tuple<int>(12);
            Console.WriteLine(tuple1.Item1);     // Displays 12
            // </Snippet2>
        }

        private static void Create2Tuple()
        {
            // <Snippet3>
            var tuple2 = Tuple.Create("New York", 32.68);
            Console.WriteLine("{0}: {1}", tuple2.Item1, tuple2.Item2);
            // Displays New York: 32.68
            // </Snippet3>
        }

        private static void New2Tuple()
        {
            // <Snippet4>
            var tuple2 = new Tuple<string, double>("New York", 32.68);
            Console.WriteLine("{0}: {1}", tuple2.Item1, tuple2.Item2);
            // Displays New York: 32.68
            // </Snippet4>
        }

        private static void Create3Tuple()
        {
            // <Snippet5>
            var tuple3 = Tuple.Create("New York", 32.68, 51.87);
            Console.WriteLine("{0}: lo {1}, hi {2}", 
                              tuple3.Item1, tuple3.Item2, tuple3.Item3);
            // Displays New York: lo 32.68, hi 51.87
            // </Snippet5>
        }

        private static void New3Tuple()
        {
            // <Snippet6>
            var tuple3 = new Tuple<string, double, double>
                                  ("New York", 32.68, 51.87);
            Console.WriteLine("{0}: lo {1}, hi {2}", 
                              tuple3.Item1, tuple3.Item2, tuple3.Item3);
            // Displays New York: lo 32.68, hi 51.87
            // </Snippet6>
        }

        private static void Create4Tuple()
        {
            // <Snippet7>
            var tuple4 = Tuple.Create("New York", 32.68, 51.87, 76.3);
            Console.WriteLine("{0}: Hi {1}, Lo {2}, Ave {3}",
                              tuple4.Item1, tuple4.Item4, tuple4.Item2,
                              tuple4.Item3);
            // Displays New York: Hi 76.3, Lo 32.68, Ave 51.87
            // </Snippet7>
        }

        private static void New4Tuple()
        {
            // <Snippet8>
            var tuple4 = new Tuple<string, double, double, double>
                                  ("New York", 32.68, 51.87, 76.3);
            Console.WriteLine("{0}: Hi {1}, Lo {2}, Ave {3}",
                              tuple4.Item1, tuple4.Item4, tuple4.Item2,
                              tuple4.Item3);
            // Displays New York: Hi 76.3, Lo 32.68, Ave 51.87
            // </Snippet8>
        }

        private static void Create5Tuple()
        {
            // <Snippet9>
            var tuple5 = Tuple.Create("New York", 1990, 7322564, 2000, 8008278);
            Console.WriteLine("{0}: {1:N0} in {2}, {3:N0} in {4}",
                              tuple5.Item1, tuple5.Item3, tuple5.Item2,
                              tuple5.Item5, tuple5.Item4);
            // Displays New York: 7,322,564 in 1990, 8,008,278 in 2000
            // </Snippet9>
        }

        private static void New5Tuple()
        {
            // <Snippet10>
            var tuple5 = new Tuple<string, int, int, int, int>
                                  ("New York", 1990, 7322564, 2000, 8008278);
            Console.WriteLine("{0}: {1:N0} in {2}, {3:N0} in {4}",
                              tuple5.Item1, tuple5.Item3, tuple5.Item2,
                              tuple5.Item5, tuple5.Item4);
            // Displays New York: 7,322,564 in 1990, 8,008,278 in 2000
            // </Snippet10>
        }

        private static void Create6Tuple()
        {
            // <Snippet11>
            var tuple6 = Tuple.Create("Jane", 90, 87, 93, 67, 100);
            Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}",
                              tuple6.Item1, tuple6.Item2, tuple6.Item3,
                              tuple6.Item4, tuple6.Item5, tuple6.Item6);
            // Displays Test scores for Jane: 90, 87, 93, 67, 100
            // </Snippet11>
        }

        private static void New6Tuple()
        {
            // <Snippet12>
            var tuple6 = new Tuple<string, int, int, int, int, int>
                                  ("Jane", 90, 87, 93, 67, 100);
            Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}",
                              tuple6.Item1, tuple6.Item2, tuple6.Item3,
                              tuple6.Item4, tuple6.Item5, tuple6.Item6);
            // Displays Test scores for Jane: 90, 87, 93, 67, 100
            // </Snippet12>
        }

        private static void Create7Tuple()
        {
            // <Snippet13>
            var tuple7 = Tuple.Create("Jane", 90, 87, 93, 67, 100, 92);
            Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}, {6}",
                              tuple7.Item1, tuple7.Item2, tuple7.Item3,
                              tuple7.Item4, tuple7.Item5, tuple7.Item6,
                              tuple7.Item7);
            // Displays Test scores for Jane: 90, 87, 93, 67, 100, 92
            // </Snippet13>
        }

        private static void New7Tuple()
        {
            // <Snippet14>
            var tuple7 = new Tuple<string, int, int, int, int, int, int>
                                  ("Jane", 90, 87, 93, 67, 100, 92);
            Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}, {6}",
                              tuple7.Item1, tuple7.Item2, tuple7.Item3,
                              tuple7.Item4, tuple7.Item5, tuple7.Item6,
                              tuple7.Item7);
            // Displays Test scores for Jane: 90, 87, 93, 67, 100, 92
            // </Snippet14>
        }

        private static void CreateNTuple()
        {
//             Tuple<int, int, int, int, int, int> innerTuple =
//                 Tuple.Create(1960, 1670140, 1980, 1203339, 2000, 951270);
//             Tuple<string, int, int, int, int, int, int,
//                 Tuple<int, int, int, int, int, int>> tuple8 =
//                 Tuple.Create("Detroit", 1900, 285704, 1920, 993078, 1940, 1623452, innerTuple);
        }

        private static void NewNTuple()
        {
            // <Snippet18>
            var innerTuple  = new Tuple<int, int, int, int, int, int>
                                       (1960, 1670140, 1980, 1203339, 
                                       2000, 951270);
            var tuple8 =
                new Tuple<string, int, int, int, int, int, int,
                Tuple<int, int, int, int, int, int>>
                ("Detroit", 1900, 285704, 1920, 993078, 1940, 1623452, innerTuple);
            Console.WriteLine("Population of {0} in:\n   {1}: {2,10:N0} \n" +
                              "   {3}: {4,10:N0} \n" + 
                              "   {5}: {6,10:N0} \n" + 
                              "   {7}: {8,10:N0} \n" + 
                              "   {9}: {10,10:N0} \n" + 
                              "   {11}: {12,10:N0} \n",
                              tuple8.Item1, tuple8.Item2, tuple8.Item3,
                              tuple8.Item4, tuple8.Item5, tuple8.Item6,
                              tuple8.Item7, tuple8.Rest.Item1, tuple8.Rest.Item2,
                              tuple8.Rest.Item3, tuple8.Rest.Item4,
                              tuple8.Rest.Item5, tuple8.Rest.Item6); 
            // The example displays the following output:
            //       Population of Detroit in:
            //          1900:    285,704
            //          1920:    993,078
            //          1940:  1,623,452
            //          1960:  1,670,140
            //          1980:  1,203,339
            //          2000:    951,270            
            // </Snippet18>
        }

        private static void Example()
        {
        var from1980 = Tuple.Create(1203339, 1027974, 951270);
        var from1910 = new Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>> 
            (465766, 993078, 1568622, 1623452, 1849568, 1670144, 1511462, from1980);
        var population = new Tuple<string, int, int, int, int, int, int,
            Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>>> 
            ("Detroit", 1860, 45619, 79577, 116340, 205876, 285704, from1910);
        }
    }
}
