using System.Diagnostics.CodeAnalysis;

namespace NullableReferenceTypes;

internal static class Examples
{
    public static void RunAll()
    {
        Annotations();
        DesignIntent();
        try
        {
            // NullStateTracking deliberately dereferences a null reference
            // to show the warning condition; the NullReferenceException
            // it throws at run time is the runtime counterpart.
            NullStateTracking();
        }
        catch (NullReferenceException)
        {
        }
        FlowAnalysis(new Node("root"));
        NullForgiving();
        NullAnalysisAttributes();
        DefaultStructPitfall();
        ArrayPitfall();
    }

    // <Annotations>
    public static void Annotations()
    {
        string required = "always set";   // non-nullable: assigning null produces a warning
        string? optional = null;          // nullable: holding null is allowed

        Console.WriteLine(required.Length);

        if (optional is not null)
        {
            Console.WriteLine(optional.Length);
        }
    }
    // </Annotations>

    // <DesignIntent>
    public sealed class Person(string firstName, string lastName)
    {
        public string FirstName { get; } = firstName;
        public string? MiddleName { get; init; }
        public string LastName { get; } = lastName;

        public override string ToString() => MiddleName is null
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MiddleName} {LastName}";
    }

    public static void DesignIntent()
    {
        Person p1 = new("Ada", "Lovelace") { MiddleName = "King" };
        Console.WriteLine(p1);
        // Output: Ada King Lovelace

        Person p2 = new("Grace", "Hopper");
        Console.WriteLine(p2);
        // Output: Grace Hopper
    }
    // </DesignIntent>

    // <NullStateTracking>
    public static void NullStateTracking()
    {
        string? message = null;

        // Warning: dereference of a possibly null reference.
        Console.WriteLine(message.Length);

        message = "Hello, World!";

        // No warning: the compiler tracks that message is now not-null.
        Console.WriteLine(message.Length);
    }
    // </NullStateTracking>

    // <FlowAnalysis>
    public sealed class Node(string name)
    {
        public string Name { get; } = name;
        public Node? Parent { get; init; }
    }

    public static void FlowAnalysis(Node start)
    {
        Node? current = start;
        while (current is not null)
        {
            // Inside the loop, the compiler knows current is not-null.
            Console.WriteLine(current.Name);

            current = current.Parent;
        }
   }
    // </FlowAnalysis>

    // <NullForgiving>
    public static void NullForgiving()
    {
        // "ada" matches a switch arm that returns a non-null string,
        // but the return type is string? so the compiler treats the
        // result as maybe-null.
        string? maybeName = LookUpName("ada");

        // The ! tells the compiler "trust me, this isn't null." We just
        // passed "ada", which the switch maps to "Ada Lovelace".
        int length = maybeName!.Length;
        Console.WriteLine(length); // => 12
    }

    // Returns string? because the wildcard arm yields null.
    private static string? LookUpName(string id) => id switch
    {
        "ada" => "Ada Lovelace",
        _ => null,
    };
    // </NullForgiving>

    // <NullAnalysisAttributes>
    public static bool IsPresent([NotNullWhen(true)] string? value) =>
        !string.IsNullOrEmpty(value);

    public static void NullAnalysisAttributes()
    {
        string? input = ReadInput();

        if (IsPresent(input))
        {
            // No null-forgiving operator needed: the attribute tells the compiler
            // input is not-null when IsPresent returns true.
            Console.WriteLine(input.Length);
        }
    }

    private static string? ReadInput() => "hello";
    // </NullAnalysisAttributes>

    // <DefaultStructPitfall>
    public struct Student
    {
        public string FirstName;
        public string? MiddleName;
        public string LastName;
    }

    public static void DefaultStructPitfall()
    {
        Student s = default;            // No warning, but FirstName and LastName are null.
        Console.WriteLine(s.FirstName?.Length ?? -1);
    }
    // </DefaultStructPitfall>

    // <ArrayPitfall>
    public static void ArrayPitfall()
    {
        string[] values = new string[3];      // Elements are null at run time.
        Console.WriteLine(values[0]?.Length ?? -1);

        string[] initialized = ["a", "b", "c"]; // Collection expression initializes every slot.
        Console.WriteLine(initialized[0].Length);
    }
    // </ArrayPitfall>
}

internal static class Program
{
    private static void Main() => Examples.RunAll();
}
