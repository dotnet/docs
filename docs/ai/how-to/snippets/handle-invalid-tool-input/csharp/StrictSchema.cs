using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string? model = config["ModelName"];
string? key = config["OpenAIKey"];

// <StrictMode>
IChatClient client = new ChatClientBuilder(
    new OpenAIClient(key).GetChatClient(model ?? "gpt-4o-2024-08-06").AsIChatClient())
    .UseFunctionInvocation()
    .Build();

// Create a function and enable strict schema mode for OpenAI
var weatherFunction = AIFunctionFactory.Create(
    (string location, int temperature, bool isRaining) =>
    {
        string weather = isRaining ? "rainy" : "clear";
        return $"Weather in {location}: {temperature}°C and {weather}";
    },
    new AIFunctionFactoryOptions
    {
        Name = "report_weather",
        Description = "Reports the weather for a location with temperature and rain status",
        // Enable strict mode by adding the Strict property
        AdditionalProperties = new Dictionary<string, object?>
        {
            { "Strict", true }
        }
    });

var chatOptions = new ChatOptions
{
    Tools = [weatherFunction]
};

List<ChatMessage> chatHistory = [
    new(ChatRole.System, "You are a weather reporting assistant."),
    new(ChatRole.User, "What's the weather in Tokyo? It's 22 degrees and not raining.")
];

ChatResponse response = await client.GetResponseAsync(chatHistory, chatOptions);
Console.WriteLine($"Assistant >>> {response.Text}");
// </StrictMode>
