using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.Text.Json;

class FunctionInvoker
{
    static async Task Main()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<FunctionInvoker>().Build();
        string? model = config["ModelName"];
        string? key = config["OpenAIKey"];

        // <BasicInvoker>
        IChatClient chatClient = new OpenAIClient(key).GetChatClient(model ?? "gpt-4o").AsIChatClient();

        var functionInvokingClient = new FunctionInvokingChatClient(chatClient)
        {
            FunctionInvoker = async (context, cancellationToken) =>
            {
                try
                {
                    // Invoke the function normally.
                    return await context.Function.InvokeAsync(context.Arguments, cancellationToken);
                }
                catch (JsonException ex)
                {
                    // Catch JSON serialization errors and provide helpful feedback.
                    return $"Error: Unable to parse the function arguments. {ex.Message}. " +
                           "Check the parameter types and try again.";
                }
                catch (Exception ex)
                {
                    // Catch all other errors.
                    return $"Error: Function execution failed - {ex.Message}";
                }
            }
        };
        // </BasicInvoker>

        IChatClient client = new ChatClientBuilder(functionInvokingClient).Build();

        var chatOptions = new ChatOptions
        {
            Tools = [AIFunctionFactory.Create((string location, int temperature) =>
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Location cannot be empty", nameof(location));
        }
        return $"Recorded temperature of {temperature}°C for {location}";
    },
    "record_temperature",
    "Records the temperature for a location")]
        };

        List<ChatMessage> chatHistory = [
            new(ChatRole.System, "You are a weather data recorder."),
    new(ChatRole.User, "Record the temperature as 25 degrees for London")
        ];

        ChatResponse response = await client.GetResponseAsync(chatHistory, chatOptions);
        Console.WriteLine($"Assistant >>> {response.Text}");
    }
}
