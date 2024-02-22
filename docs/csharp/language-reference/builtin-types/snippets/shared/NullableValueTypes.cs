namespace builtin_types;

public static class NullableValueTypes
{
    public static void Examples()
    {
        DeclareAndAssign();
        ExamineValueOfNullableType();
        UseNullCoalescingOperator();
        Operators();
        ComparisonOperators();
        BoxingAndUnboxing();
        WhetherTypeIsNullable();
        GetTypeExample();
        IsOperatorExample();
    }

    private static void DeclareAndAssign()
    {
        // <SnippetDeclaration>
        double? pi = 3.14;
        char? letter = 'a';

        int m2 = 10;
        int? m = m2;

        bool? flag = null;

        // An array of a nullable value type:
        int?[] arr = new int?[10];
        // </SnippetDeclaration>
    }

    private static void ExamineValueOfNullableType()
    {
        // <SnippetPatternMatching>
        int? a = 42;
        if (a is int valueOfA)
        {
            Console.WriteLine($"a is {valueOfA}");
        }
        else
        {
            Console.WriteLine("a does not have a value");
        }
        // Output:
        // a is 42
        // </SnippetPatternMatching>

        // <SnippetHasValue>
        int? b = 10;
        if (b.HasValue)
        {
            Console.WriteLine($"b is {b.Value}");
        }
        else
        {
            Console.WriteLine("b does not have a value");
        }
        // Output:
        // b is 10
        // </SnippetHasValue>

        // <SnippetCompareWithNull>
        int? c = 7;
        if (c != null)
        {
            Console.WriteLine($"c is {c.Value}");
        }
        else
        {
            Console.WriteLine("c does not have a value");
        }
        // Output:
        // c is 7
        // </SnippetCompareWithNull>
    }

    private static void UseNullCoalescingOperator()
    {
        // <SnippetNullCoalescing>
        int? a = 28;
        int b = a ?? -1;
        Console.WriteLine($"b is {b}");  // output: b is 28

        int? c = null;
        int d = c ?? -1;
        Console.WriteLine($"d is {d}");  // output: d is -1
        // </SnippetNullCoalescing>
    }

    private static void ExplicitCast()
    {
        // <SnippetCast>
        int? n = null;

        //int m1 = n;    // Doesn't compile
        int n2 = (int)n; // Compiles, but throws an exception if n is null
        // </SnippetCast>
    }

    private static void Operators()
    {
        // <SnippetLiftedOperator>
        int? a = 10;
        int? b = null;
        int? c = 10;

        a++;        // a is 11
        a = a * c;  // a is 110
        a = a + b;  // a is null
        // </SnippetLiftedOperator>
    }

    private static void ComparisonOperators()
    {
        // <SnippetComparisonOperators>
        int? a = 10;
        Console.WriteLine($"{a} >= null is {a >= null}");
        Console.WriteLine($"{a} < null is {a < null}");
        Console.WriteLine($"{a} == null is {a == null}");
        // Output:
        // 10 >= null is False
        // 10 < null is False
        // 10 == null is False

        int? b = null;
        int? c = null;
        Console.WriteLine($"null >= null is {b >= c}");
        Console.WriteLine($"null == null is {b == c}");
        // Output:
        // null >= null is False
        // null == null is True
        // </SnippetComparisonOperators>
    }

    private static void BoxingAndUnboxing()
    {
        // <SnippetBoxing>
        int a = 41;
        object aBoxed = a;
        int? aNullable = (int?)aBoxed;
        Console.WriteLine($"Value of aNullable: {aNullable}");

        object aNullableBoxed = aNullable;
        if (aNullableBoxed is int valueOfA)
        {
            Console.WriteLine($"aNullableBoxed is boxed int: {valueOfA}");
        }
        // Output:
        // Value of aNullable: 41
        // aNullableBoxed is boxed int: 41
        // </SnippetBoxing>
    }

    private static void WhetherTypeIsNullable()
    {
        // <SnippetIsTypeNullable>
        Console.WriteLine($"int? is {(IsNullable(typeof(int?)) ? "nullable" : "non nullable")} value type");
        Console.WriteLine($"int is {(IsNullable(typeof(int)) ? "nullable" : "non-nullable")} value type");

        bool IsNullable(Type type) => Nullable.GetUnderlyingType(type) != null;

        // Output:
        // int? is nullable value type
        // int is non-nullable value type
        // </SnippetIsTypeNullable>
    }

    private static void GetTypeExample()
    {
        // <SnippetGetType>
        int? a = 17;
        Type typeOfA = a.GetType();
        Console.WriteLine(typeOfA.FullName);
        // Output:
        // System.Int32
        // </SnippetGetType>
    }

    private static void IsOperatorExample()
    {
        // <SnippetIsOperator>
        int? a = 14;
        if (a is int)
        {
            Console.WriteLine("int? instance is compatible with int");
        }

        int b = 17;
        if (b is int?)
        {
            Console.WriteLine("int instance is compatible with int?");
        }
        // Output:
        // int? instance is compatible with int
        // int instance is compatible with int?
        // </SnippetIsOperator>
    }
}
