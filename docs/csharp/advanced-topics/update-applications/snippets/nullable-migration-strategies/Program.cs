namespace MigrationStrategies;

internal static class Examples
{
    public static void RunAll()
    {
        Console.WriteLine(LegacyHelper.GetGreeting("ada"));
        Console.WriteLine(MigratedHelper.GetGreeting("ada"));
    }
}

// <DirectiveOverrides>
#nullable disable
public static class LegacyHelper
{
    // This file is nullable-oblivious. Reference types use the legacy rules.
    public static string GetGreeting(string name) =>
        name == null ? "hello" : $"hello {name}";
}
#nullable restore

#nullable enable
public static class MigratedHelper
{
    // This file is fully migrated. Reference types are non-nullable by default.
    public static string GetGreeting(string? name) =>
        name is null ? "hello" : $"hello {name}";
}
#nullable restore
// </DirectiveOverrides>

internal static class Program
{
    private static void Main() => Examples.RunAll();
}
