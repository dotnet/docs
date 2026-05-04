using System.Diagnostics.CodeAnalysis;

namespace NullableReferenceTypes;

internal static class Examples
{
    public static void RunAll()
    {
        Annotations();
        DesignIntent();
        NullStateTracking();
        FlowAnalysis(new Node("root"));
        NullForgiving();
        NullAnalysisAttributes();
        Generics();
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

        public string FullName => MiddleName is null
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MiddleName} {LastName}";
    }

    public static void DesignIntent()
    {
        Person p = new("Ada", "Lovelace") { MiddleName = "King" };
        Console.WriteLine(p.FullName);
    }
    // </DesignIntent>

    // <NullStateTracking>
    public static void NullStateTracking()
    {
        string? message = null;

        // Warning: dereference of a possibly null reference.
        // Console.WriteLine(message.Length);

        string? originalMessage = message;
        message = "Hello, World!";

        // No warning: the compiler tracks that message is now not-null.
        Console.WriteLine(message.Length);

        // Warning: originalMessage might be null.
        // Console.WriteLine(originalMessage.Length);
        _ = originalMessage;
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
        for (Node? current = start; current is not null; current = current.Parent)
        {
            // Inside the loop, the compiler knows current is not-null.
            Console.WriteLine(current.Name);
        }
    }
    // </FlowAnalysis>

    // <NullForgiving>
    public static void NullForgiving()
    {
        string? maybeName = LookUpName("ada");

        // The compiler can't prove maybeName isn't null. The developer can.
        int length = maybeName!.Length;
        Console.WriteLine(length);
    }

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

    // <Generics>
    public static T? FirstOrDefault<T>(IEnumerable<T> source)
    {
        foreach (T item in source)
        {
            return item;
        }
        return default;
    }

    public static void RequireNotNull<T>(T value) where T : notnull
    {
        ArgumentNullException.ThrowIfNull(value);
    }

    public static void Generics()
    {
        string? first = FirstOrDefault<string>([]);
        Console.WriteLine(first ?? "<empty>");

        RequireNotNull("not null");
    }
    // </Generics>

    // <DefaultStructPitfall>
#pragma warning disable CS0649 // Fields are deliberately uninitialized to show the pitfall.
    public struct Student
    {
        public string FirstName;
        public string? MiddleName;
        public string LastName;
    }
#pragma warning restore CS0649

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
