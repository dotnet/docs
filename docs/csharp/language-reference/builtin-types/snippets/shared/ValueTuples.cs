// <AliasTupleType>
global using BandPass = (int Min, int Max);
// </AliasTupleType>

namespace builtin_types;

public static class ValueTuples
{
    public static void Examples()
    {
        Intro();
        MethodsOnTuples();
        LargeTuple();
        MultipleReturns();
        ExplicitFieldNames();
        InferFieldNames();
        DefaultFieldNames();
        TupleAssignment();
        DeconstructExplicit();
        DeconstructVar();
        DeconstructExisting();
        TupleEquality();
        TupleEvaluationForEquality();
        TupleAsOutParameter();
        DeconstructToPattern();

        // <UseAliasType>
        BandPass bracket = (40, 100);
        Console.WriteLine($"The bandpass filter is {bracket.Min} to {bracket.Max}");
        // </UseAliasType>
    }

    private static void DeconstructToPattern()
    {
        // <DeconstructToPattern>
        for(int i = 4; i < 20;  i++)
        {
            if (Math.DivRem(i, 3) is { Remainder: 0, Quotient: var q })
            {
                Console.WriteLine($"{i} is divisible by 3, with quotient {q}");
            }
        }
        // </DeconstructToPattern>
    }

    private static void Intro()
    {
        // <SnippetIntroduction>
        (double, int) t1 = (4.5, 3);
        Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");
        // Output:
        // Tuple with elements 4.5 and 3.

        (double Sum, int Count) t2 = (4.5, 3);
        Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
        // Output:
        // Sum of 3 elements is 4.5.
        // </SnippetIntroduction>
    }

    private static void MethodsOnTuples()
    {
        // <SnippetMethodOnTuples>
        (double, int) t = (4.5, 3);
        Console.WriteLine(t.ToString());
        Console.WriteLine($"Hash code of {t} is {t.GetHashCode()}.");
        // Output:
        // (4.5, 3)
        // Hash code of (4.5, 3) is 718460086.
        // </SnippetMethodOnTuples>
    }

    private static void LargeTuple()
    {
        // <SnippetLargeTuple>
        var t =
        (1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        11, 12, 13, 14, 15, 16, 17, 18,
        19, 20, 21, 22, 23, 24, 25, 26);
        Console.WriteLine(t.Item26);  // output: 26
        // </SnippetLargeTuple>
    }

    private static void MultipleReturns()
    {
        // <SnippetMultipleReturns>
        var xs = new[] { 4, 7, 9 };
        var limits = FindMinMax(xs);
        Console.WriteLine($"Limits of [{string.Join(" ", xs)}] are {limits.min} and {limits.max}");
        // Output:
        // Limits of [4 7 9] are 4 and 9

        var ys = new[] { -9, 0, 67, 100 };
        var (minimum, maximum) = FindMinMax(ys);
        Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");
        // Output:
        // Limits of [-9 0 67 100] are -9 and 100

        (int min, int max) FindMinMax(int[] input)
        {
            if (input is null || input.Length == 0)
            {
                throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
            }

            // Initialize min to MaxValue so every value in the input
            // is less than this initial value.
            var min = int.MaxValue;
            // Initialize max to MinValue so every value in the input
            // is greater than this initial value.
            var max = int.MinValue;
            foreach (var i in input)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            return (min, max);
        }
        // </SnippetMultipleReturns>
    }

    private static void ExplicitFieldNames()
    {
        // <SnippetExplicitFieldNames>
        var t = (Sum: 4.5, Count: 3);
        Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");

        (double Sum, int Count) d = (4.5, 3);
        Console.WriteLine($"Sum of {d.Count} elements is {d.Sum}.");
        // </SnippetExplicitFieldNames>
    }

    private static void InferFieldNames()
    {
        // <SnippetInferFieldNames>
        var sum = 4.5;
        var count = 3;
        var t = (sum, count);
        Console.WriteLine($"Sum of {t.count} elements is {t.sum}.");
        // </SnippetInferFieldNames>
    }

    private static void DefaultFieldNames()
    {
        // <SnippetDefaultFieldNames>
        var a = 1;
        var t = (a, b: 2, 3);
        Console.WriteLine($"The 1st element is {t.Item1} (same as {t.a}).");
        Console.WriteLine($"The 2nd element is {t.Item2} (same as {t.b}).");
        Console.WriteLine($"The 3rd element is {t.Item3}.");
        // Output:
        // The 1st element is 1 (same as 1).
        // The 2nd element is 2 (same as 2).
        // The 3rd element is 3.
        // </SnippetDefaultFieldNames>
    }

    private static void TupleAssignment()
    {
        // <SnippetAssignment>
        (int, double) t1 = (17, 3.14);
        (double First, double Second) t2 = (0.0, 1.0);
        t2 = t1;
        Console.WriteLine($"{nameof(t2)}: {t2.First} and {t2.Second}");
        // Output:
        // t2: 17 and 3.14

        (double A, double B) t3 = (2.0, 3.0);
        t3 = t2;
        Console.WriteLine($"{nameof(t3)}: {t3.A} and {t3.B}");
        // Output:
        // t3: 17 and 3.14
        // </SnippetAssignment>
    }

    private static void DeconstructExplicit()
    {
        // <SnippetDeconstructExplicit>
        var t = ("post office", 3.6);
        (string destination, double distance) = t;
        Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
        // Output:
        // Distance to post office is 3.6 kilometers.
        // </SnippetDeconstructExplicit>
    }

    private static void DeconstructVar()
    {
        // <SnippetDeconstructVar>
        var t = ("post office", 3.6);
        var (destination, distance) = t;
        Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
        // Output:
        // Distance to post office is 3.6 kilometers.
        // </SnippetDeconstructVar>
    }

    private static void DeconstructExisting()
    {
        // <SnippetDeconstructExisting>
        var destination = string.Empty;
        var distance = 0.0;

        var t = ("post office", 3.6);
        (destination, distance) = t;
        Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
        // Output:
        // Distance to post office is 3.6 kilometers.
        // </SnippetDeconstructExisting>
    }

    private static void TupleEquality()
    {
        // <SnippetTupleEquality>
        (int a, byte b) left = (5, 10);
        (long a, int b) right = (5, 10);
        Console.WriteLine(left == right);  // output: True
        Console.WriteLine(left != right);  // output: False

        var t1 = (A: 5, B: 10);
        var t2 = (B: 5, A: 10);
        Console.WriteLine(t1 == t2);  // output: True
        Console.WriteLine(t1 != t2);  // output: False
        // </SnippetTupleEquality>
    }

    private static void TupleEvaluationForEquality()
    {
        // <SnippetTupleEvaluationForEquality>
        Console.WriteLine((Display(1), Display(2)) == (Display(3), Display(4)));

        int Display(int s)
        {
            Console.WriteLine(s);
            return s;
        }
        // Output:
        // 1
        // 2
        // 3
        // 4
        // False
        // </SnippetTupleEvaluationForEquality>
    }

    private static void TupleAsOutParameter()
    {
        // <SnippetTupleAsOutParameter>
        var limitsLookup = new Dictionary<int, (int Min, int Max)>()
        {
            [2] = (4, 10),
            [4] = (10, 20),
            [6] = (0, 23)
        };

        if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits))
        {
            Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
        }
        // Output:
        // Found limits: min is 10, max is 20
        // </SnippetTupleAsOutParameter>
    }
}
