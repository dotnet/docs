using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddInMemoryCollection(initialData: [
            new("port", "5001"),
            new("enabled", "true"),
            new("apiUrl", "https://jsonplaceholder.typicode.com/")
        ]);

var configuration = builder.Build();

var settings = new Settings();
configuration.Bind(settings);

// Write the values to the console.
Console.WriteLine($"Port = {settings.Port}");
Console.WriteLine($"Enabled = {settings.Enabled}");
Console.WriteLine($"API URL = {settings.ApiUrl}");

class Settings
{
    public int Port { get; set; }
    public bool Enabled { get; set; }
    public string? ApiUrl { get; set; }
}

// This will output the following:
//   Port = 5001
//   Enabled = True
//   API URL = https://jsonplaceholder.typicode.com/
