namespace object_collection_initializers;

// <SnippetObjectInitializerWithoutNew>
public class ObjectInitializerWithoutNew
{
    public class Address
    {
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
    }

    public class Person
    {
        public string Name { get; set; } = "";
        public Address HomeAddress { get; set; } = new Address(); // Property with setter
    }

    public static void Examples()
    {
        // Example 1: Using object initializer WITHOUT 'new' keyword
        // This modifies the existing Address instance created in the constructor
        var person1 = new Person
        {
            Name = "Alice",
            HomeAddress = { Street = "123 Main St", City = "Anytown", State = "CA" }
        };
        
        // Example 2: Using object initializer WITH 'new' keyword
        // This creates a completely new Address instance
        var person2 = new Person
        {
            Name = "Bob",
            HomeAddress = new Address { Street = "456 Oak Ave", City = "Somewhere", State = "NY" }
        };

        // Both approaches work, but they behave differently:
        // - person1.HomeAddress is the same instance that was created in Person's constructor
        // - person2.HomeAddress is a new instance, replacing the one from the constructor

        Console.WriteLine($"Person 1: {person1.Name} at {person1.HomeAddress.Street}, {person1.HomeAddress.City}, {person1.HomeAddress.State}");
        Console.WriteLine($"Person 2: {person2.Name} at {person2.HomeAddress.Street}, {person2.HomeAddress.City}, {person2.HomeAddress.State}");
    }
}
// </SnippetObjectInitializerWithoutNew>

// <SnippetReadOnlyPropertyExample>
public class ReadOnlyPropertyExample
{
    public class Settings
    {
        public string Theme { get; set; } = "Light";
        public int FontSize { get; set; } = 12;
    }

    public class Application
    {
        public string Name { get; set; } = "";
        // This property is read-only - it can only be set during construction
        public Settings AppSettings { get; } = new Settings();
    }

    public static void Example()
    {
        // You can still initialize the nested object's properties
        // even though AppSettings property has no setter
        var app = new Application
        {
            Name = "MyApp",
            AppSettings = { Theme = "Dark", FontSize = 14 }
        };

        // This would cause a compile error because AppSettings has no setter:
        // app.AppSettings = new Settings { Theme = "Dark", FontSize = 14 };

        Console.WriteLine($"App: {app.Name}, Theme: {app.AppSettings.Theme}, Font Size: {app.AppSettings.FontSize}");
    }
}
// </SnippetReadOnlyPropertyExample>