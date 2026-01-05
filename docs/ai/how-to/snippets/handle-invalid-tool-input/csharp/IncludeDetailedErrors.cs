using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

// <BasicUsage>
IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string? model = config["ModelName"];
string? key = config["OpenAIKey"];

IChatClient client = new ChatClientBuilder(
    new OpenAIClient(key).GetChatClient(model ?? "gpt-4o").AsIChatClient())
    .UseFunctionInvocation()
    .Build();

// Enable detailed error messages to help the AI model self-correct
var functionInvokingClient = client as FunctionInvokingChatClient;
if (functionInvokingClient != null)
{
    functionInvokingClient.IncludeDetailedErrors = true;
}

var chatOptions = new ChatOptions
{
    Tools = [AIFunctionFactory.Create((int temperature, string location) =>
    {
        // Validate temperature is in a reasonable range
        if (temperature < -50 || temperature > 50)
        {
            throw new ArgumentOutOfRangeException(nameof(temperature), 
                "Temperature must be between -50 and 50 degrees Celsius.");
        }
        return $"The temperature in {location} is {temperature}°C";
    },
    "get_temperature",
    "Gets the current temperature for a location")]
};

List<ChatMessage> chatHistory = [
    new(ChatRole.System, "You are a helpful weather assistant."),
    new(ChatRole.User, "What's the temperature in Paris?")
];

ChatResponse response = await client.GetResponseAsync(chatHistory, chatOptions);
Console.WriteLine($"Assistant >>> {response.Text}");
// </BasicUsage>
