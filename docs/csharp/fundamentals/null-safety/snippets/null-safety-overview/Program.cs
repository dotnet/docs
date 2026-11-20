namespace NullSafetyOverview;

public static class Program
{
    public static void Main()
    {
        NullReferenceDemo();
        NvtIntro();
        NrtIntro();
        OperatorsQuickRef();
    }

    private static void NullReferenceDemo()
    {
        // <NullReferenceDemo>
        // Accessing a member on null throws NullReferenceException at runtime:
        // string? name = null;
        // int length = name.Length; // throws NullReferenceException

        // Check before you dereference:
        string? name = null;
        if (name is not null)
        {
            Console.WriteLine($"Name has {name.Length} characters.");
        }
        else
        {
            Console.WriteLine("Name has no value.");
        }
        // Output: Name has no value.
        // </NullReferenceDemo>
    }

    private static void NvtIntro()
    {
        // <NvtIntro>
        int? score = null;
        Console.WriteLine(score.HasValue);               // False

        score = 95;
        Console.WriteLine(score.HasValue);               // True
        Console.WriteLine(score.GetValueOrDefault());    // 95

        int? missing = null;
        Console.WriteLine(missing.GetValueOrDefault(-1)); // -1
        // </NvtIntro>
    }

    private static void NrtIntro()
    {
        // <NrtIntro>
        // string?  means this reference might be null
        // string   means this reference should not be null
        string? nullableName = null;
        string  nonNullName  = "Alice";

        // ?. safely accesses a member when the reference might be null
        string display = nullableName?.ToUpper() ?? "(no name)";
        Console.WriteLine(display);         // (no name)

        display = nonNullName.ToUpper();    // safe: nonNullName is never null
        Console.WriteLine(display);         // ALICE
        // </NrtIntro>
    }

    private static void OperatorsQuickRef()
    {
        // <OperatorsQuickRef>
        string? city = GetCity();

        // ?. — access a member only when non-null
        int? len = city?.Length;

        // ?? — substitute a default when null
        string display = city ?? "unknown";

        // is null — preferred null test
        if (city is null)
        {
            Console.WriteLine("No city provided.");
        }
        else
        {
            Console.WriteLine($"{display} ({len} chars)");
        }
        // Output: No city provided.
        // </OperatorsQuickRef>
    }

    private static string? GetCity() => null;
}
