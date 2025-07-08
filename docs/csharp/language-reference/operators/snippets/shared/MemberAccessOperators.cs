// <SnippetNestedNamespace>
using System.Collections.Generic;
// </SnippetNestedNamespace>

namespace operators;

public static class MemberAccessOperators
{
    public static void Examples()
    {
        TypeMemberAccess();
        Arrays();
        Indexers();
        NullConditional();
        NullConditionalWithNullCoalescing();
        Invocation();
        IndexFromEnd();
        Ranges();
        RangesOptional();
        RangesAllPossible();
    }

    private static void QualifiedName()
    {
        // <SnippetQualifiedName>
        System.Collections.Generic.IEnumerable<int> numbers = [1, 2, 3];
        // </SnippetQualifiedName>
    }

    private static void TypeMemberAccess()
    {
        // <SnippetTypeMemberAccess>
        List<double> constants =
        [
            Math.PI,
            Math.E
        ];
        Console.WriteLine($"{constants.Count} values to show:");
        Console.WriteLine(string.Join(", ", constants));
        // Output:
        // 2 values to show:
        // 3.14159265358979, 2.71828182845905
        // </SnippetTypeMemberAccess>
    }

    private static void Arrays()
    {
        // <SnippetArrays>
        int[] fib = new int[10];
        fib[0] = fib[1] = 1;
        for (int i = 2; i < fib.Length; i++)
        {
            fib[i] = fib[i - 1] + fib[i - 2];
        }
        Console.WriteLine(fib[fib.Length - 1]);  // output: 55

        double[,] matrix = new double[2,2];
        matrix[0,0] = 1.0;
        matrix[0,1] = 2.0;
        matrix[1,0] = matrix[1,1] = 3.0;
        var determinant = matrix[0,0] * matrix[1,1] - matrix[1,0] * matrix[0,1];
        Console.WriteLine(determinant);  // output: -3
        // </SnippetArrays>
    }

    private static void Indexers()
    {
        // <SnippetIndexers>
        var dict = new Dictionary<string, double>();
        dict["one"] = 1;
        dict["pi"] = Math.PI;
        Console.WriteLine(dict["one"] + dict["pi"]);  // output: 4.14159265358979
        // </SnippetIndexers>
    }

    private static void NullConditional()
    {
        // <SnippetNullConditional>
        double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
        }

        var sum1 = SumNumbers(null, 0);
        Console.WriteLine(sum1);  // output: NaN

        List<double[]?> numberSets =
        [
            [1.0, 2.0, 3.0],
            null
        ];

        var sum2 = SumNumbers(numberSets, 0);
        Console.WriteLine(sum2);  // output: 6

        var sum3 = SumNumbers(numberSets, 1);
        Console.WriteLine(sum3);  // output: NaN
        // </SnippetNullConditional>
    }

    private static void NullConditionalWithNullCoalescing()
    {
        // <SnippetNullConditionalWithNullCoalescing>
        int GetSumOfFirstTwoOrDefault(int[]? numbers)
        {
            if ((numbers?.Length ?? 0) < 2)
            {
                return 0;
            }
            return numbers[0] + numbers[1];
        }

        Console.WriteLine(GetSumOfFirstTwoOrDefault(null));  // output: 0
        Console.WriteLine(GetSumOfFirstTwoOrDefault([]));  // output: 0
        Console.WriteLine(GetSumOfFirstTwoOrDefault([3, 4, 5]));  // output: 7
        // </SnippetNullConditionalWithNullCoalescing>
    }

    private static void Invocation()
    {
        // <SnippetInvocation>
        Action<int> display = s => Console.WriteLine(s);

        List<int> numbers =
        [
            10,
            17
        ];
        display(numbers.Count);   // output: 2

        numbers.Clear();
        display(numbers.Count);   // output: 0
        // </SnippetInvocation>
    }

    private static void IndexFromEnd()
    {
        // <SnippetIndexFromEnd>
        int[] xs = [0, 10, 20, 30, 40];
        int last = xs[^1];
        Console.WriteLine(last);  // output: 40

        List<string> lines = ["one", "two", "three", "four"];
        string prelast = lines[^2];
        Console.WriteLine(prelast);  // output: three

        string word = "Twenty";
        Index toFirst = ^word.Length;
        char first = word[toFirst];
        Console.WriteLine(first);  // output: T
        // </SnippetIndexFromEnd>
    }

    private static void Ranges()
    {
        // <SnippetRanges>
        int[] numbers = [0, 10, 20, 30, 40, 50];
        int start = 1;
        int amountToTake = 3;
        int[] subset = numbers[start..(start + amountToTake)];
        Display(subset);  // output: 10 20 30

        int margin = 1;
        int[] inner = numbers[margin..^margin];
        Display(inner);  // output: 10 20 30 40

        string line = "one two three";
        int amountToTakeFromEnd = 5;
        Range endIndices = ^amountToTakeFromEnd..^0;
        string end = line[endIndices];
        Console.WriteLine(end);  // output: three

        void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));
        // </SnippetRanges>
    }

    private static void RangesOptional()
    {
        // <SnippetRangesOptional>
        int[] numbers = [0, 10, 20, 30, 40, 50];
        int amountToDrop = numbers.Length / 2;

        int[] rightHalf = numbers[amountToDrop..];
        Display(rightHalf);  // output: 30 40 50

        int[] leftHalf = numbers[..^amountToDrop];
        Display(leftHalf);  // output: 0 10 20

        int[] all = numbers[..];
        Display(all);  // output: 0 10 20 30 40 50

        void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));
        // </SnippetRangesOptional>
    }

    private static void RangesAllPossible()
    {
        // <RangesAllPossible>
        int[] oneThroughTen =
        [
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        ];

        Write(oneThroughTen, ..);
        Write(oneThroughTen, ..3);
        Write(oneThroughTen, 2..);
        Write(oneThroughTen, 3..5);
        Write(oneThroughTen, ^2..);
        Write(oneThroughTen, ..^3);
        Write(oneThroughTen, 3..^4);
        Write(oneThroughTen, ^4..^2);

        static void Write(int[] values, Range range) =>
            Console.WriteLine($"{range}:\t{string.Join(", ", values[range])}");
        // Sample output:
        //      0..^0:      1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        //      0..3:       1, 2, 3
        //      2..^0:      3, 4, 5, 6, 7, 8, 9, 10
        //      3..5:       4, 5
        //      ^2..^0:     9, 10
        //      0..^3:      1, 2, 3, 4, 5, 6, 7
        //      3..^4:      4, 5, 6
        //      ^4..^2:     7, 8
        // </RangesAllPossible>
    }
}
