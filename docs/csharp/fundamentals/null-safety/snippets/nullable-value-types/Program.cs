namespace NullableValueTypesSample;

public static class Program
{
    public static void Main()
    {
        ShowDeclaration();
        ShowPatternMatching();
        ShowHasValue();
        ShowNullCheck();
        ShowGetValueOrDefault();
        ShowNullCoalescing();
        ShowLiftedOperators();
    }

    private static void ShowDeclaration()
    {
        // <Declaration>
        int?    age      = null;    // integer with no value yet
        double? price    = 9.99;    // nullable double with a value
        bool?   isActive = null;    // boolean with no value

        age = 30;                   // assign a value later

        int?[] scores = [100, null, 85, null, 72]; // array with absent entries
        // </Declaration>

        // Suppress unused-variable warnings — these variables are shown for documentation.
        _ = age;
        _ = price;
        _ = isActive;
        _ = scores;
    }

    private static void ShowPatternMatching()
    {
        // <PatternMatching>
        int? temperature = 72;

        if (temperature is int degrees)
        {
            Console.WriteLine($"Temperature is {degrees}°F.");
        }
        else
        {
            Console.WriteLine("Temperature is not recorded.");
        }
        // Output: Temperature is 72°F.
        // </PatternMatching>
    }

    private static void ShowHasValue()
    {
        // <HasValue>
        int? count = 42;

        if (count.HasValue)
        {
            Console.WriteLine($"Count is {count.Value}.");
        }
        else
        {
            Console.WriteLine("Count has no value.");
        }
        // Output: Count is 42.
        // </HasValue>
    }

    private static void ShowNullCheck()
    {
        // <NullCheck>
        int? quantity = null;

        if (quantity != null)
        {
            Console.WriteLine($"Quantity: {quantity.Value}");
        }
        else
        {
            Console.WriteLine("Quantity is not set.");
        }
        // Output: Quantity is not set.
        // </NullCheck>
    }

    private static void ShowGetValueOrDefault()
    {
        // <GetValueOrDefault>
        int? rating = null;

        int result1 = rating.GetValueOrDefault();    // 0 (default for int)
        int result2 = rating.GetValueOrDefault(-1);  // -1 (specified fallback)

        Console.WriteLine(result1); // 0
        Console.WriteLine(result2); // -1

        rating = 5;
        int result3 = rating.GetValueOrDefault(-1);  // 5 (actual value)
        Console.WriteLine(result3); // 5
        // </GetValueOrDefault>
    }

    private static void ShowNullCoalescing()
    {
        // <NullCoalescing>
        int? priority = null;

        int effective = priority ?? 0;  // 0 because priority is null
        Console.WriteLine(effective);   // 0

        priority  = 3;
        effective = priority ?? 0;      // 3 because priority has a value
        Console.WriteLine(effective);   // 3
        // </NullCoalescing>
    }

    private static void ShowLiftedOperators()
    {
        // <LiftedOperators>
        int? a = 10;
        int? b = 20;
        int? c = null;

        int? sum     = a + b;   // both non-null: result is 30
        int? product = a * c;   // one operand is null: result is null

        Console.WriteLine(sum);               // 30
        Console.WriteLine(product.HasValue);  // False — null propagates through arithmetic
        // </LiftedOperators>
    }
}
