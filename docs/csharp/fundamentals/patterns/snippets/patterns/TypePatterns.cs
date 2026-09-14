using System.IO;

static class TypePatterns
{
    public static void Run()
    {
        Console.WriteLine(IsText("notes"));
        Console.WriteLine(DescribeResource(new MemoryStream()));
        Console.WriteLine(IsCompatible<int, object>(42));
        Console.WriteLine(TryGetMatch<object, string>("ready", out string? match));
        Console.WriteLine(match);
    }

    // <TypePattern>
    static bool IsText(object? value) => value is string;
    // </TypePattern>

    // <TypePatternSwitch>
    static string DescribeResource(object? resource) =>
        resource switch
        {
            MemoryStream => "An in-memory stream",
            Stream => "Another kind of stream",
            IDisposable => "A disposable resource",
            null => "No resource",
            _ => "Another value"
        };
    // </TypePatternSwitch>

    // <GenericTypePattern>
    static bool IsCompatible<TInput, TMatch>(TInput value) =>
        value is TMatch;
    // </GenericTypePattern>

    // <GenericDeclarationPattern>
    static bool TryGetMatch<TInput, TMatch>(TInput value, out TMatch? match)
    {
        if (value is TMatch found)
        {
            match = found;
            return true;
        }

        match = default;
        return false;
    }
    // </GenericDeclarationPattern>
}
