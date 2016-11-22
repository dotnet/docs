using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuples
{
    public static class StatisticsVersionOne
    {
        #region 05_StandardDeviation
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            // Step 1: Compute the Mean:
            var mean = sequence.Average();

            // Step 2: Compute the square of the differences between each number 
            // and the mean:
            var squaredMeanDifferences = from n in sequence
                                         select (n - mean) * (n - mean);
            // Step 3: Find the mean of those squared differences:
            var meanOfSquaredDifferences = squaredMeanDifferences.Average();

            // Step 4: Standard Deviation is the square root of that mean:
            var standardDeviation = Math.Sqrt(meanOfSquaredDifferences);
            return standardDeviation;
        }
        #endregion
    }

    public static class StatisticsVersionTwo
    {
        #region 06_SumOfSquaresFormula
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            double sum = 0;
            double sumOfSquares = 0;
            double count = 0;

            foreach (var item in sequence)
            {
                count++;
                sum += item;
                sumOfSquares += item * item;
            }

            var variance = sumOfSquares - sum * sum / count;
            return Math.Sqrt(variance / count);
        }
        #endregion
    }

    public static class StatisticsVersionThree
    {
        #region 07_TupleVersion
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            var computation = (sum: 0.0, sumOfSquares: 0.0, count: 0);

            foreach (var item in sequence)
            {
                computation.count++;
                computation.sum += item;
                computation.sumOfSquares += item * item;
            }

            var variance = computation.sumOfSquares - computation.sum * computation.sum / computation.count;
            return Math.Sqrt(variance / computation.count);
        }
        #endregion
    }

    public static class StatisticsVersionFour
    {
        #region 08_TupleMethodVersion
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            (double Sum, double SumOfSquares, int Count) computation = ComputeSumsAnSumOfdSquares(sequence);

            var variance = computation.SumOfSquares - computation.Sum * computation.Sum / computation.Count;
            return Math.Sqrt(variance / computation.Count);
        }

        private static (double Sum, double SumOfSquares, int Count) ComputeSumsAnSumOfdSquares(IEnumerable<double> sequence)
        {
            var computation = (sum: 0.0, sumOfSquares: 0.0, count: 0);

            foreach (var item in sequence)
            {
                computation.count++;
                computation.sum += item;
                computation.sumOfSquares += item * item;
            }

            return computation;
        }
        #endregion
    }

    public static class StatisticsVersionFive
    {
        #region 09_CleanedTupleVersion
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            var computation = ComputeSumAndSumOfSquares(sequence);

            var variance = computation.SumOfSquares - computation.Sum * computation.Sum / computation.Count;
            return Math.Sqrt(variance / computation.Count);
        }

        private static (double Sum, double SumOfSquares, int Count) ComputeSumAndSumOfSquares(IEnumerable<double> sequence)
        {
            double sum = 0;
            double sumOfSquares = 0;
            int count = 0;

            foreach (var item in sequence)
            {
                count++;
                sum += item;
                sumOfSquares += item * item;
            }

            return (sum, sumOfSquares, count);
        }
        #endregion
    }


    public static class StatisticsVersionSix
    {
        #region 10_Deconstruct
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            (double sum, double sumOfSquares, int count) = ComputeSumAndSumOfSquares(sequence);

            var variance = sumOfSquares - sum * sum / count;
            return Math.Sqrt(variance / count);
        }
        #endregion

        private static (double Sum, double SumOfSquares, int Count) ComputeSumAndSumOfSquares(IEnumerable<double> sequence)
        {
            double sum = 0;
            double sumOfSquares = 0;
            int count = 0;

            foreach (var item in sequence)
            {
                count++;
                sum += item;
                sumOfSquares += item * item;
            }

            return (sum, sumOfSquares, count);
        }
    }

    public static class StatisticsVersionSeven
    {
        #region 11_DeconstructToVar
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            var (sum, sumOfSquares, count) = ComputeSumAndSumOfSquares(sequence);

            var variance = sumOfSquares - sum * sum / count;
            return Math.Sqrt(variance / count);
        }
        #endregion

        private static (double Sum, double SumOfSquares, int Count) ComputeSumAndSumOfSquares(IEnumerable<double> sequence)
        {
            double sum = 0;
            double sumOfSquares = 0;
            int count = 0;

            foreach (var item in sequence)
            {
                count++;
                sum += item;
                sumOfSquares += item * item;
            }

            return (sum, sumOfSquares, count);
        }
    }
}
