// <NamespaceBasics>
using System;

namespace MyApp.Services;

class Greeter
{
    public void Greet(string name) => Console.WriteLine($"Hello, {name}!");
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
        greeter.Greet("World");
        Console.WriteLine(new MyApp.Models.Customer { Name = "Alice" });
        QualifiedProductNames.ShowQualifiedNames();
        ProductNames.ShowAliases();
        Console.WriteLine(Imports.CreateMessage());
        Console.WriteLine(GlobalMessage.CreateMessage());
        Console.WriteLine(new CustomerService().GetTopCustomers().Count);
        Console.WriteLine(MyApp.Geometry.Shape.Distance((0, 0), (3, 4)));
        Console.WriteLine(MyApp.Utilities.CircleCalculator.CalculateArea(1) == Math.PI);

        List<string> names = ["Alice", "Bob"];
        Console.WriteLine(names.Count);
    }
}
