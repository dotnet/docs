using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NameofSample;

public static class Program
{
    public static void Main()
    {
        ShowBasic();
        ShowGuardClause();
        ShowThrowIfNull();
        ShowPropertyChanged();
        ShowAttributeUsage();
        ShowUnboundGenerics();
        ShowQualifiedName();
    }

    private static void ShowBasic()
    {
        // <Basic>
        // nameof produces the textual identifier of a symbol at compile time.
        Console.WriteLine(nameof(Customer));        // Customer
        Console.WriteLine(nameof(Customer.Name));   // Name

        var customer = new Customer("Ada");
        Console.WriteLine(nameof(customer));        // customer
        Console.WriteLine(nameof(customer.Name));   // Name
        // </Basic>
    }

    private static void ShowGuardClause()
    {
        // <GuardClause>
        try
        {
            Greet("");
        }
        catch (ArgumentException ex)
        {
            // The exception's ParamName is the literal "name", produced by nameof at compile time.
            Console.WriteLine($"{ex.ParamName}: {ex.Message.Split(' ')[0]}");
        }

        static void Greet(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name must be non-empty.", nameof(name));
            }
            Console.WriteLine($"Hello, {name}!");
        }
        // </GuardClause>
    }

    private static void ShowThrowIfNull()
    {
        // <ThrowIfNull>
        // ArgumentNullException.ThrowIfNull captures the argument's name automatically
        // through [CallerArgumentExpression], so a separate nameof isn't required for
        // the null check. Use nameof for cases the helpers don't cover.
        Customer? maybeCustomer = null;

        try
        {
            Save(maybeCustomer);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.ParamName);   // maybeCustomer
        }

        static void Save(Customer? customer)
        {
            ArgumentNullException.ThrowIfNull(customer);
            // ...
        }
        // </ThrowIfNull>
    }

    private static void ShowPropertyChanged()
    {
        // <PropertyChanged>
        var person = new Person();
        person.PropertyChanged += (_, e) => Console.WriteLine($"changed: {e.PropertyName}");

        person.Name = "Ada";    // changed: Name
        person.Name = "Grace";  // changed: Name
        // </PropertyChanged>
    }

    private static void ShowAttributeUsage()
    {
        // <AttributeUsage>
        // nameof works inside attribute arguments. The compiler resolves the
        // identifier even when the attribute targets a method or its parameters.
        Console.WriteLine(NormalizeOrNull("  hi  ") ?? "<null>");   // hi
        Console.WriteLine(NormalizeOrNull(null) ?? "<null>");        // <null>

        [return: NotNullIfNotNull(nameof(input))]
        static string? NormalizeOrNull(string? input) => input?.Trim();
        // </AttributeUsage>
    }

    private static void ShowUnboundGenerics()
    {
        // <UnboundGenerics>
        // Beginning in C# 14, nameof accepts an unbound generic type.
        // The result is the simple type name without any type-argument list.
        Console.WriteLine(nameof(List<>));                  // List
        Console.WriteLine(nameof(Dictionary<,>));           // Dictionary
        // </UnboundGenerics>
    }

    private static void ShowQualifiedName()
    {
        // <QualifiedName>
        // For a qualified expression, nameof returns only the final identifier.
        Console.WriteLine(nameof(System.Collections.Generic.List<int>)); // List
        Console.WriteLine(nameof(Customer.Name));                        // Name
        // </QualifiedName>
    }
}

// <CustomerType>
public sealed record Customer(string Name);
// </CustomerType>

// <PersonType>
public sealed class Person : INotifyPropertyChanged
{
    private string _name = "";

    public string Name
    {
        get => _name;
        set
        {
            if (_name == value) return;
            _name = value;
            // nameof keeps the property name and the change notification in sync.
            // Renaming the property automatically updates this argument.
            OnPropertyChanged(nameof(Name));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
// </PersonType>
