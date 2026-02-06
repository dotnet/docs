using Microsoft.Extensions.Configuration;

// <DictionaryWithCollectionValues>
// Demo: Dictionary binding with collection values extends, not replaces (since .NET 7)
IConfiguration config = new ConfigurationBuilder()
    .AddInMemoryCollection()
    .Build();

config["Queue:0"] = "Value1";
var dict = new Dictionary<string, string[]>() { { "Queue", new[] { "InitialValue" } } };

Console.WriteLine("=== Dictionary Binding with Collection Values ===");
Console.WriteLine($"Initially: {string.Join(", ", dict["Queue"])}");

// In .NET 7+, binding extends the collection instead of replacing it
config.Bind(dict);
Console.WriteLine($"After Bind: {string.Join(", ", dict["Queue"])}");

config["Queue:1"] = "Value2";
config.Bind(dict);
Console.WriteLine($"After 2nd Bind: {string.Join(", ", dict["Queue"])}");
// </DictionaryWithCollectionValues>

Console.WriteLine();

// <DictionaryKeysWithColons>
// Demo: Colons in dictionary keys are NOT supported (used as hierarchy delimiter)
Console.WriteLine("=== Dictionary Keys with Colons (NOT Supported) ===");

var colonConfig = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        // Using double underscore instead of colon (e.g., "http://example.com" becomes "http__//example.com")
        ["MyDict:http__//example.com"] = "value1",  
        ["MyDict:normalkey"] = "value2"
    })
    .Build();

var dictWithKeys = new Dictionary<string, string>();
colonConfig.GetSection("MyDict").Bind(dictWithKeys);

Console.WriteLine("Keys retrieved from config:");
foreach (var kvp in dictWithKeys)
{
    Console.WriteLine($"  '{kvp.Key}' = '{kvp.Value}'");
}
Console.WriteLine("Note: Use alternative delimiters (like '__') instead of colons in keys");
// </DictionaryKeysWithColons>

Console.WriteLine();

// <IReadOnlyCollections>
// Demo: IReadOnly* types are NOT directly bindable - use mutable types
Console.WriteLine("=== IReadOnly* Types (NOT Directly Supported) ===");

var readonlyConfig = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        ["Settings:Values:0"] = "Item1",
        ["Settings:Values:1"] = "Item2",
        ["Settings:Values:2"] = "Item3",
    })
    .Build();

// This class uses List<string> for binding, exposes as IReadOnlyList<string>
var settings = new SettingsWithReadOnly();
readonlyConfig.GetSection("Settings").Bind(settings);

Console.WriteLine("Values bound to mutable List, exposed as IReadOnlyList:");
foreach (var value in settings.ValuesReadOnly)
{
    Console.WriteLine($"  {value}");
}
// </IReadOnlyCollections>

Console.WriteLine();

// <ParameterizedConstructor>
// Demo: Single parameterized constructor binding (supported in .NET 7+)
Console.WriteLine("=== Parameterized Constructor Binding ===");

var ctorConfig = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        ["AppSettings:Name"] = "MyApp",
        ["AppSettings:MaxConnections"] = "100",
        ["AppSettings:Timeout"] = "30"
    })
    .Build();

// Binding to a type with a single parameterized constructor
var appSettings = ctorConfig.GetSection("AppSettings").Get<AppSettings>();
if (appSettings != null)
{
    Console.WriteLine($"Name: {appSettings.Name}");
    Console.WriteLine($"MaxConnections: {appSettings.MaxConnections}");
    Console.WriteLine($"Timeout: {appSettings.Timeout}");
}

Console.WriteLine("\nNote: Multiple parameterized constructors are NOT supported.");
// </ParameterizedConstructor>

// <SettingsWithReadOnly>
class SettingsWithReadOnly
{
    // Use mutable type for binding
    public List<string> Values { get; set; } = new();

    // Expose as read-only for consumers
    public IReadOnlyList<string> ValuesReadOnly => Values;
}
// </SettingsWithReadOnly>

// <AppSettings>
// Immutable type with single parameterized constructor
class AppSettings
{
    public string Name { get; }
    public int MaxConnections { get; }
    public int Timeout { get; }

    public AppSettings(string name, int maxConnections, int timeout)
    {
        Name = name;
        MaxConnections = maxConnections;
        Timeout = timeout;
    }
}
// </AppSettings>
