using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializationStatements();

            AssignmentStatements();

            var sample = new List<double> { 2.0, 4.0, 6.0, 8.0 };

            Console.WriteLine(StatisticsVersionOne.StandardDeviation(sample));

            Console.WriteLine(StatisticsVersionTwo.StandardDeviation(sample));
            Console.WriteLine(StatisticsVersionThree.StandardDeviation(sample));
            Console.WriteLine(StatisticsVersionFour.StandardDeviation(sample));

            #region 12A_DeconstructType
            var p = new Person("Althea", "Goodwin");
            var (first, last) = p;
            #endregion
            Console.WriteLine(first);
            Console.WriteLine(last);

            #region 13A_DeconstructExtension
            var s1 = new Student("Cary", "Totten", 4.5);
            var (fName, lName, gpa) = s1;
            #endregion

            var (f, l) = s1;

            var source = new ProjectionSample();
            var sequence = source.GetCurrentItemsMobileList();
            foreach (var item in sequence)
                Console.WriteLine($"{item.ID}, {item.Title}");

            FunWithProjections();

            // Declare different members and tuples:

            SimpleTupleEquality();
            NullableTupleEquality();
            MemberConversions();
            MemberNameConversions();

            TupleEquality.Tests.EqualityTests();

            TupleAsOutVariable();
        }

        private static void SimpleTupleEquality()
        {
            // <SnippetEquality>
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            Console.WriteLine(left == right); // displays 'true'
            // </SnippetEquality>
        }

        private static void NullableTupleEquality()
        {
            // <SnippetNullableEquality>
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            (int a, int b)? nullableTuple = right;
            Console.WriteLine(left == nullableTuple); // Also true
            // </SnippetNullableEquality>
        }

        private static void MemberConversions()
        {
            // <SnippetMemberConversions>
            // lifted conversions
            var left = (a: 5, b: 10);
            (int? a, int? b) nullableMembers = (5, 10);
            Console.WriteLine(left == nullableMembers); // Also true

            // converted type of left is (long, long)
            (long a, long b) longTuple = (5, 10);
            Console.WriteLine(left == longTuple); // Also true

            // comparisons performed on (long, long) tuples
            (long a, int b) longFirst = (5, 10);
            (int a, long b) longSecond = (5, 10);
            Console.WriteLine(longFirst == longSecond); // Also true
            // </SnippetMemberConversions>
        }

        private static void MemberNameConversions()
        { 
            // <SnippetMemberNames>
            (int a, string b) pair = (1, "Hello");
            (int z, string y) another = (1, "Hello");
            Console.WriteLine(pair == another); // true. Member names don't participate.
            Console.WriteLine(pair == (z: 1, y: "Hello")); // warning: literal contains different member names
            // </SnippetMemberNames>

            //<SnippetNestedTuples>
            (int, (int, int)) nestedTuple = (1, (2, 3));
            Console.WriteLine(nestedTuple == (1, (2, 3)) );
            // </SnippetNestedTuples>

            // Value based equality tests (Person)
        }

        private static void FunWithProjections()
        {
            #region ProjectionExample_Explicit
            var localVariableOne = 5;
            var localVariableTwo = "some text";

            var tuple = (explicitFieldOne: localVariableOne, explicitFieldTwo: localVariableTwo);
            #endregion

            #region MixedTuple
            var stringContent = "The answer to everything";
            var mixedTuple = (42, stringContent);
            #endregion

            #region ProjectionAmbiguities
            var ToString = "This is some text";
            var one = 1;
            var Item1 = 5;
            var projections = (ToString, one, Item1);
            // Accessing the first field:
            Console.WriteLine(projections.Item1);
            // There is no semantic name 'ToString'
            // Accessing the second field:
            Console.WriteLine(projections.one);
            Console.WriteLine(projections.Item2);
            // Accessing the third field:
            Console.WriteLine(projections.Item3);
            // There is no semantic name 'Item1`.

            var pt1 = (X: 3, Y: 0);
            var pt2 = (X: 3, Y: 4);

            var xCoords = (pt1.X, pt2.X);
            // There are no semantic names for the fields
            // of xCoords. 

            // Accessing the first field:
            Console.WriteLine(xCoords.Item1);
            // Accessing the second field:
            Console.WriteLine(xCoords.Item2);
            #endregion
        }

        private static void AssignmentStatements()
        {
            #region 03_VariableCreation
            // The 'arity' and 'shape' of all these tuples are compatible. 
            // The only difference is the field names being used.
            var unnamed = (42, "The meaning of life");
            var anonymous = (16, "a perfect square");
            var named = (Answer: 42, Message: "The meaning of life");
            var differentNamed = (SecretConstant: 42, Label: "The meaning of life");
            #endregion

            #region 04_VariableAssignment
            unnamed = named;

            named = unnamed;
            // 'named' still has fields that can be referred to
            // as 'answer', and 'message':
            Console.WriteLine($"{named.Answer}, {named.Message}");

            // unnamed to unnamed:
            anonymous = unnamed;
            
            // named tuples.
            named = differentNamed;
            // The field names are not assigned. 'named' still has 
            // fields that can be referred to as 'answer' and 'message':
            Console.WriteLine($"{named.Answer}, {named.Message}");

            // With implicit conversions:
            // int can be implicitly converted to long
            (long, string) conversion = named;
            #endregion

        }

        private static void InitializationStatements()
        {
            #region 01_UnNamedTuple
            var unnamed = ("one", "two");
            #endregion

            #region 02_NamedTuple
            var named = (first: "one", second: "two");
            #endregion

            #region ProjectedTupleNames
            var sum = 12.5;
            var count = 5;
            var accumulation = (count, sum);
            #endregion
        }

        private static double VersionThree(IEnumerable<double> sequence)
        {
            var computation = (Sum: 0.0, SumOfSquares: 0.0, Items: 0);

            foreach (var item in sequence)
            {
                computation.Items++;
                computation.Sum += item;
                computation.SumOfSquares += item * item;
            }

            var variance = computation.SumOfSquares - computation.Sum * computation.Sum / computation.Items;
            return Math.Sqrt(variance / computation.Items);
        }

        private static double VersionFour(IEnumerable<double> sequence)
        {
            var coreStats = ComputeCoreStats(sequence);

            var variance = coreStats.sumOfSquares - coreStats.sum * coreStats.sum / coreStats.items;
            return Math.Sqrt(variance / coreStats.items);
        }

        // Remove names, and it can be an unnamed tuple.
        private static (int items, double sum, double sumOfSquares) ComputeCoreStats(IEnumerable<double> sequence)
        {
            double total = 0;
            double sumOfSquares = 0;
            int items = 0;

            foreach (var item in sequence)
            {
                items++;
                total += item;
                sumOfSquares += item * item;
            }
            return (items, total, sumOfSquares);
        }

        private static void TupleAsOutVariable()
        {
            #region 01_TupleAsOutVariable
            Dictionary<int, (int, string)> dict = new Dictionary<int, (int, string)>();
            dict.Add(1, (234, "First!"));
            dict.Add(2, (345, "Second"));
            dict.Add(3, (456, "Last"));

            // TryGetValue already demonstrates using out parameters
            dict.TryGetValue(2, out (int num, string place) pair);

            Console.WriteLine($"{pair.num}: {pair.place}");

            /*
             * Output:
             * 345: Second
             */
            #endregion
        }
    }
}
