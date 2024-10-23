using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddInMemoryCollection(initialData: [
            new("port", "5001"),
            new("enabled", "true"),
            new("apiUrl", "https://jsonplaceholder.typicode.com/")
        ]);

var configuration = builder.Build();

var port = configuration.GetValue<int>("port");
var enabled = configuration.GetValue<bool>("enabled");
var apiUrl = configuration.GetValue<Uri>("apiUrl");

// Write the values to the console.
Console.WriteLine($"Port = {port}");
Console.WriteLine($"Enabled = {enabled}");
Console.WriteLine($"API URL = {apiUrl}");

// This will output the following:
//   Port = 5001
//   Enabled = True
//   API URL = https://jsonplaceholder.typicode.com/
