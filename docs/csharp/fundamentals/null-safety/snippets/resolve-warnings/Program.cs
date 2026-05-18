using System.Diagnostics.CodeAnalysis;

namespace ResolveWarnings;

internal static class Examples
{
    public static void RunAll()
    {
        DereferenceFixed("hello");
        NullOperatorsFix(null);
        AssignmentFixed("ada");
        CallerWithAttribute("ada");
        UseInitialized();
    }

    // <NullableDirective>
#nullable enable
    public static int Length(string? message) =>
        message?.Length ?? 0;
    // </NullableDirective>

    // <DereferenceWarning>
    public static int LengthOfMessageUnsafe(string? message)
    {
        // Warning CS8602: dereference of a possibly null reference.
        return message.Length;
    }
    // </DereferenceWarning>

    // <DereferenceFixed>
    public static int DereferenceFixed(string? message)
    {
        if (message is null)
        {
            return 0;
        }

        // No warning: the compiler knows message is not-null on this path.
        return message.Length;
    }
    // </DereferenceFixed>

    // <NullOperatorsFix>
    public static int NullOperatorsFix(string? message)
    {
        // ?. evaluates to null if message is null; ?? supplies the fallback value.
        int length = message?.Length ?? 0;

        // Pattern matching narrows the type on the matching branch.
        if (message is { Length: > 0 } nonEmpty)
        {
            length = nonEmpty.Length;
        }

        return length;
    }
    // </NullOperatorsFix>

    private static string? Lookup(string id) => id == "ada" ? "Ada Lovelace" : null;

    // <AssignmentWarning>
    public static void AssignmentWarning()
    {
        // Warning CS8600: converting null literal or possible null value to non-nullable type.
        string name = Lookup("nobody");
        Console.WriteLine(name);
    }
    // </AssignmentWarning>

    // <AssignmentFixed>
    public static void AssignmentFixed(string id)
    {
        string? name = Lookup(id);
        if (name is not null)
        {
            Console.WriteLine(name);
        }
    }
    // </AssignmentFixed>

    // <MissingAttribute>
    public static bool IsPresent(string? text) =>
        !string.IsNullOrEmpty(text);

    public static void CallerWithoutAttribute(string? text)
    {
        if (IsPresent(text))
        {
            // Warning CS8602: dereference of a possibly null reference.
            // The signature doesn't tell the compiler text is not-null here.
            Console.WriteLine(text.Length);
        }
    }
    // </MissingAttribute>

    // <WithAttribute>
    public static bool AttributedIsPresent([NotNullWhen(true)] string? text) =>
        !string.IsNullOrEmpty(text);

    public static void CallerWithAttribute(string? text)
    {
        if (AttributedIsPresent(text))
        {
            // No warning: the attribute tells the compiler text is not-null.
            Console.WriteLine(text.Length);
        }
    }
    // </WithAttribute>

    // <UninitializedMember>
    public class PersonUninitialized
    {
        // Warning CS8618: Non-nullable property 'Name' is uninitialized.
        public string Name { get; set; }
    }
    // </UninitializedMember>

    // <ConstructorInjected>
    public class PersonInjected(string name)
    {
        public string Name { get; } = name;
    }
    // </ConstructorInjected>

    // <RequiredMember>
    public class PersonRequired
    {
        public required string Name { get; init; }
    }
    // </RequiredMember>

    // <InitializedMember>
    public class PersonInitialized
    {
        public string Name { get; set; } = "John Doe";
    }
    // </InitializedMember>

    // <NullableMember>
    public class PersonOptional
    {
        public string? Name { get; set; }
    }
    // </NullableMember>

    public static void UseInitialized()
    {
        PersonInjected p1 = new("Ada");
        PersonRequired p2 = new() { Name = "Ada" };
        PersonInitialized p3 = new();
        PersonOptional p4 = new();

        Console.WriteLine($"{p1.Name}|{p2.Name}|{p3.Name}|{p4.Name ?? "<unset>"}");
    }
}

internal static class Program
{
    private static void Main() => Examples.RunAll();
}
