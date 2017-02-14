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

            var sample = new List<double>{ 2.0, 4.0, 6.0, 8.0 };

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
            // unnamed to named:
            unnamed = named;

            // named to unnamed:
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
    }
}
