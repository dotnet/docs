using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_in_7
{
    class Numerics
    {
        #region 32_BinaryConstants
        public const int One =  0b0001;
        public const int Two =  0b0010;
        public const int Four = 0b0100;
        public const int Eight = 0b1000;
        #endregion

        #region 33_ThousandSeparators
        public const int Sixteen =   0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;
        #endregion

        #region 34_LargeIntegers
        public const long BillionsAndBillions = 100_000_000_000;
        #endregion

        #region 35_OtherConstants
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
        #endregion

    }
    class Program
    {
        static void Main(string[] args)
        {
            OutVariableDeclarations();
            TupleDeclarations();
            TupleMethod();

            #region 12_DeconstructPoint
            var p = new Point(3.14, 2.71);
            (double X, double Y) = p;
            #endregion
            WriteLine(X);
            WriteLine(Y);

            #region 13_DeconstructNames
            (double horizontalDistance, double verticalDistance) = p;
            #endregion
            WriteLine(horizontalDistance);
            WriteLine(verticalDistance);

            int[,] matrix = new int[10, 10];
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    matrix[x, y] = x * 10 + y;

            #region 21_UpdateItemFromIndices
            var indices = MatrixSearch.Find(matrix, (val) => val == 42);
            Console.WriteLine(indices);
            matrix[indices.i, indices.j] = 24;
            #endregion

            matrix[indices.i, indices.j] = 42;

            #region 23_AssignRefReturnToValue
            var valItem = MatrixSearch.Find3(matrix, (val) => val == 42);
            Console.WriteLine(valItem);
            valItem = 24;
            Console.WriteLine(matrix[4, 2]);
            #endregion

            #region 24_AssignRefReturn
            ref var item = ref MatrixSearch.Find3(matrix, (val) => val == 42);
            Console.WriteLine(item);
            item = 24;
            Console.WriteLine(matrix[4, 2]);
            #endregion

            try
            {
                #region 26_CallIteratorMethod
                var resultSet = Iterator.AlphabetSubset('f', 'a');
                Console.WriteLine("iterator created");
                foreach (var thing in resultSet)
                    Console.Write($"{thing}, ");
                #endregion 
            } catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine(MathUtilities.LocalFunctionFactorial(1));
            Console.WriteLine(MathUtilities.LocalFunctionFactorial(2));
            Console.WriteLine(MathUtilities.LocalFunctionFactorial(3));
            Console.WriteLine(MathUtilities.LocalFunctionFactorial(4));
            Console.WriteLine(MathUtilities.LocalFunctionFactorial(5));

            Console.WriteLine(MathUtilities.LambdaFactorial(1));
            Console.WriteLine(MathUtilities.LambdaFactorial(2));
            Console.WriteLine(MathUtilities.LambdaFactorial(3));
            Console.WriteLine(MathUtilities.LambdaFactorial(4));
            Console.WriteLine(MathUtilities.LambdaFactorial(5));
            
        }

        private static void TupleMethod()
        {
            var numbers = new int[] { 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            #region 09_CallingTupleMethod
            var range = Range(numbers);
            #endregion
            WriteLine(range);

            #region 10_CallingWithDeconstructor
            (int max, int min) = Range(numbers);
            #endregion
            WriteLine(max);
            WriteLine(min);
        }

        #region 08_TupleReturningMethod
        private static (int Max, int Min) Range(IEnumerable<int> numbers)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach(var n in numbers)
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
            }
            return (max, min);
        }
        #endregion


        private static void TupleDeclarations()
        {
            #region 04_UnnamedTuple
            var letters = ("a", "b");
            #endregion

            #region 05_NamedTuple
            (string Alpha, string Beta) namedLetters = ("a", "b");
            #endregion

            #region 06_ImplicitNamedTuple
            var alphabetStart = (Alpha: "a", Beta: "b");
            #endregion

            #region 07_NamedTupleConflict
            (string First, string Second) firstLetters = (Alpha: "a", Beta: "b");
            #endregion
        }

        private static void OutVariableDeclarations()
        {
            var input = "1234";
            #region 01_OutVariableDeclarations
            if (int.TryParse(input, out int result))
                WriteLine(result);
            else
                WriteLine("Could not parse input");
            #endregion
            #region 02_OutVarVariableDeclarations
            if (int.TryParse(input, out var answer))
                WriteLine(answer);
            else
                WriteLine("Could not parse input");
            #endregion
            #region 03_OutVariableOldStyle
            int numericResult;
            if (int.TryParse(input, out numericResult))
                WriteLine(numericResult);
            else
                WriteLine("Could not parse input");

            #endregion
        }
    }
}
