using System;
using System.Collections.Generic;

namespace new_in_7
{
    class Numerics
    {
        // <SnippetThousandSeparators>
        public const int Sixteen =   0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;
        // </SnippetThousandSeparators>

        // <SnippetLargeIntegers>
        public const long BillionsAndBillions = 100_000_000_000;
        // </SnippetLargeIntegers>

        // <SnippetOtherConstants>
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
        // </SnippetOtherConstants>
    }
    class Program
    {
        static void Main(string[] args)
        {
            OutVariableDeclarations();
            TupleDeclarations();
            TupleMethod();

            // <SnippetDeconstructPoint>
            var p = new Point(3.14, 2.71);
            (double X, double Y) = p;
            // </SnippetDeconstructPoint>
            Console.WriteLine(X);
            Console.WriteLine(Y);

            Patterns.IsPatternTestOne();

            Patterns.SwitchPatternSimple();
            Patterns.SwitchPatternFull();

            MatrixSearch.EverythingByValue();

            int[,] matrix = new int[10, 10];
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    matrix[x, y] = x * 10 + y;

            // <SnippetAssignRefReturn>
            ref var item = ref MatrixSearch.Find(matrix, (val) => val == 42);
            Console.WriteLine(item);
            item = 24;
            Console.WriteLine(matrix[4, 2]);
            // </SnippetAssignRefReturn>

            Iterator.IteratorTest();
            Iterator.IteratorTestLocal();

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
            // <SnippetTupleReturningMethod>
            (int Max, int Min) Range(IEnumerable<int> sequence)
            {
                int Min = int.MaxValue;
                int Max = int.MinValue;
                foreach (var n in sequence)
                {
                    Min = (n < Min) ? n : Min;
                    Max = (n > Max) ? n : Max;
                }
                return (Max, Min);
            }

            var numbers = new int[] { 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            var range = Range(numbers);
            Console.WriteLine(range);
            // </SnippetTupleReturningMethod>

            // <SnippetCallingWithDeconstructor>
            (int max, int min) = Range(numbers);
            Console.WriteLine(max);
            Console.WriteLine(min);
            // </SnippetCallingWithDeconstructor>

            // <SnippetDiscardMember>
            (int maxValue, _) = Range(numbers);
            Console.WriteLine(max);
            // </SnippetDiscardMember>
        }

        private static void TupleDeclarations()
        {

            // <SnippetNamedTuple>
            (string Alpha, string Beta) namedLetters = ("a", "b");
            Console.WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");
            // </SnippetNamedTuple>

            // <SnippetImplicitNamedTuple>
            var alphabetStart = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{alphabetStart.Alpha}, {alphabetStart.Beta}");
            // </SnippetImplicitNamedTuple>
        }

        private static void OutVariableDeclarations()
        {
            // <SnippetOutVariableOldStyle>
            var input = "1234";
            int numericResult;
            if (int.TryParse(input, out numericResult))
                Console.WriteLine(numericResult);
            else
                Console.WriteLine("Could not parse input");
            // </SnippetOutVariableOldStyle>

            // <SnippetOutVariableDeclarations>
            if (int.TryParse(input, out int result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not parse input");
            // </SnippetOutVariableDeclarations>

            // <SnippetOutVarVariableDeclarations>
            if (int.TryParse(input, out var answer))
                Console.WriteLine(answer);
            else
                Console.WriteLine("Could not parse input");
            // </SnippetOutVarVariableDeclarations>
        }
    }
}
