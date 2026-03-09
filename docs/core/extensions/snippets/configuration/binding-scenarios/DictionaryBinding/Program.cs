using Microsoft.Extensions.Configuration;

// <DictionaryWithCollectionValues>
IConfiguration config = new ConfigurationBuilder()
    .AddInMemoryCollection()
    .Build();

config["Queue:0"] = "Value1";
var dict = new Dictionary<string, string[]>() { { "Queue", new[] { "InitialValue" } } };

Console.WriteLine("=== Dictionary Binding with Collection Values ===");
Console.WriteLine($"Initially: {string.Join(", ", dict["Queue"])}");

// In .NET 7+, binding extends the collection instead of replacing it.
config.Bind(dict);
Console.WriteLine($"After Bind: {string.Join(", ", dict["Queue"])}");

config["Queue:1"] = "Value2";
config.Bind(dict);
Console.WriteLine($"After 2nd Bind: {string.Join(", ", dict["Queue"])}");
// </DictionaryWithCollectionValues>

Console.WriteLine();

// <IReadOnlyCollections>
Console.WriteLine("=== IReadOnly* Types (NOT Directly Supported) ===");

var readonlyConfig = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        ["Settings:Values:0"] = "Item1",
        ["Settings:Values:1"] = "Item2",
        ["Settings:Values:2"] = "Item3",
    })
    .Build();

// This class uses List<string> for binding, exposes as IReadOnlyList<string>.
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
// </ParameterizedConstructor>

// <SettingsWithReadOnly>
class SettingsWithReadOnly
{
    // Use mutable type for binding
    public List<string> Values { get; set; } = [];

    // Expose as read-only for consumers
    public IReadOnlyList<string> ValuesReadOnly => Values;
}
// </SettingsWithReadOnly>

// <AppSettings>
// Immutable type with single parameterized constructor.
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
