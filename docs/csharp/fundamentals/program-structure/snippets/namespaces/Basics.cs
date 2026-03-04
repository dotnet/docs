// <NamespaceBasics>
using System.Globalization;

namespace MyApp.Services;

class Greeter
{
    public string Greet(string name)
    {
        var culture = CultureInfo.CurrentCulture;
        return $"Hello, {name}! Culture: {culture.Name}";
    }
}
// </NamespaceBasics>

class Program
{
    // <FullyQualifiedName>
    static void ShowFullyQualified()
    {
        // Without a using directive, use the fully qualified name:
        System.Console.WriteLine("Hello from fully qualified name!");
    }
    // </FullyQualifiedName>

    // <UsingDirective>
    static void ShowShortName()
    {
        // With 'using System;' (or implicit usings enabled), use the short name:
        Console.WriteLine("Hello from short name!");
    }
    // </UsingDirective>

    static void Main()
    {
        ShowFullyQualified();
        ShowShortName();

        var greeter = new Greeter();
        Console.WriteLine(greeter.Greet("World"));
    }
}
