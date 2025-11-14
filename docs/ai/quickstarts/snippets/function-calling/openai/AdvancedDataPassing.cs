// <SnippetUsingAIFunctionArguments>
using Microsoft.Extensions.AI;

// Function that accepts AIFunctionArguments to access all arguments
AIFunction functionWithArgs = AIFunctionFactory.Create(
    (AIFunctionArguments args) =>
    {
        // Access named parameters from the arguments dictionary
        string location = args["location"]?.ToString() ?? "Unknown";
        string unit = args["unit"]?.ToString() ?? "celsius";
        
        // Access the Context dictionary for additional data
        if (args.Context.TryGetValue("userId", out var userId))
        {
            Console.WriteLine($"Getting weather for user: {userId}");
        }
        
        return $"Weather in {location}: 22°{unit}";
    },
    name: "get_weather",
    description: "Get the current weather");
// </SnippetUsingAIFunctionArguments>

// <SnippetUsingIServiceProvider>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.AI;

// Setup dependency injection
var services = new ServiceCollection();
services.AddSingleton<IWeatherService, WeatherService>();
IServiceProvider serviceProvider = services.BuildServiceProvider();

// Function that accepts IServiceProvider to resolve dependencies
AIFunction functionWithDI = AIFunctionFactory.Create(
    (string location, IServiceProvider services) =>
    {
        var weatherService = services.GetRequiredService<IWeatherService>();
        return weatherService.GetWeather(location);
    },
    name: "get_weather",
    description: "Get the current weather");

// When invoking, provide the service provider
var args = new AIFunctionArguments
{
    ["location"] = "Seattle",
    Services = serviceProvider
};
// </SnippetUsingIServiceProvider>

// <SnippetUsingCurrentContext>
using Microsoft.Extensions.AI;

// Function that uses CurrentContext to access invocation metadata
AIFunction functionWithContext = AIFunctionFactory.Create(
    (string location) =>
    {
        // Access the current function invocation context
        var context = FunctionInvokingChatClient.CurrentContext;
        
        if (context != null)
        {
            Console.WriteLine($"Function: {context.Function.Metadata.Name}");
            Console.WriteLine($"Call ID: {context.CallId}");
            
            // Access chat history or other context data
            foreach (var message in context.ChatHistory)
            {
                Console.WriteLine($"Previous message: {message.Text}");
            }
        }
        
        return $"Weather in {location}: Sunny, 75°F";
    },
    name: "get_weather",
    description: "Get the current weather");
// </SnippetUsingCurrentContext>

// <SnippetCustomParameterBinding>
using System.Reflection;
using Microsoft.Extensions.AI;

// Custom parameter binding to source data from Context dictionary
var options = new AIFunctionFactoryOptions
{
    ConfigureParameterBinding = (ParameterInfo parameter) =>
    {
        // Bind 'userId' parameter from Context instead of arguments
        if (parameter.Name == "userId")
        {
            return new AIFunctionFactoryOptions.ParameterBindingOptions
            {
                // Custom binding logic
                BindParameter = (paramInfo, args) =>
                {
                    // Get value from Context dictionary
                    if (args.Context.TryGetValue("userId", out var value))
                    {
                        return value;
                    }
                    
                    // Return default if not found
                    return paramInfo.HasDefaultValue ? paramInfo.DefaultValue : null;
                }
            };
        }
        
        // Use default binding for other parameters
        return default;
    }
};

// Create function with custom parameter binding
AIFunction functionWithCustomBinding = AIFunctionFactory.Create(
    method: (string location, string userId) =>
    {
        Console.WriteLine($"Getting weather for user {userId} in {location}");
        return $"Weather in {location}: Cloudy, 65°F";
    },
    options: options);

// When invoking, pass userId via Context
var customArgs = new AIFunctionArguments
{
    ["location"] = "Portland",
    Context = { ["userId"] = "user123" }
};
// </SnippetCustomParameterBinding>

// When invoking, pass userId via Context
var customArgs = new AIFunctionArguments
{
    ["location"] = "Portland",
    Context = { ["userId"] = "user123" }
};
// </SnippetCustomParameterBinding>

// <SnippetCompleteExample>
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI;

// Setup services
var services = new ServiceCollection();
services.AddSingleton<IUserContext, UserContext>();
IServiceProvider provider = services.BuildServiceProvider();

// Configure AI client
IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string? model = config["ModelName"];
string? key = config["OpenAIKey"];

IChatClient client =
    new ChatClientBuilder(new OpenAIClient(key).GetChatClient(model ?? "gpt-4o").AsIChatClient())
    .UseFunctionInvocation()
    .Build();

// Create function with dependency injection
var chatOptions = new ChatOptions
{
    Tools = [AIFunctionFactory.Create(
        (string location, IServiceProvider services) =>
        {
            var userContext = services.GetRequiredService<IUserContext>();
            Console.WriteLine($"User {userContext.UserId} requesting weather for {location}");
            return $"Weather in {location}: 70°F and sunny";
        },
        "get_weather",
        "Get the current weather in a given location")]
};

// Prepare chat with service provider
List<ChatMessage> chatHistory = [
    new(ChatRole.System, "You are a helpful weather assistant.")
];
chatHistory.Add(new ChatMessage(ChatRole.User, "What's the weather in Boston?"));

// Pass service provider when making the request
var functionArgs = new AIFunctionArguments
{
    Services = provider
};

ChatResponse response = await client.GetResponseAsync(chatHistory, chatOptions);
Console.WriteLine($"Response: {response.Text}");
// </SnippetCompleteExample>

// <SnippetSupportingTypes>
// Supporting types for examples
public interface IWeatherService
{
    string GetWeather(string location);
}

public class WeatherService : IWeatherService
{
    public string GetWeather(string location)
    {
        return $"Weather in {location}: Partly cloudy, 68°F";
    }
}

public interface IUserContext
{
    string UserId { get; }
}

public class UserContext : IUserContext
{
    public string UserId { get; set; } = "default-user";
}
// </SnippetSupportingTypes>
