using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args).Build();

// Ask the service provider for the configuration abstraction.
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

// Get values from the config given their key and their target type.
int keyOneValue = config.GetValue<int>("KeyOne");
bool keyTwoValue = config.GetValue<bool>("KeyTwo");
string keyThreeNestedValue = config.GetValue<string>("KeyThree:Message");

// Write the values to the console.
Console.WriteLine($"KeyOne = {keyOneValue}");
Console.WriteLine($"KeyTwo = {keyTwoValue}");
Console.WriteLine($"KeyThree:Message = {keyThreeNestedValue}");

// Application code which might rely on the config could start here.

await host.RunAsync();

// This will output the following:
//   KeyOne = 1
//   KeyTwo = True
//   KeyThree:Message = Thanks for checking this out!
