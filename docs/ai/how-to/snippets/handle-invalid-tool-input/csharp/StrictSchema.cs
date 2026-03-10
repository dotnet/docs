using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

class StrictSchema
{
    static async Task Main()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<StrictSchema>().Build();
        string? model = config["ModelName"];
        string? key = config["OpenAIKey"];

        // Ensure your model configuration uses a compatible version (e.g., gpt-4o-2024-08-06 or later).
        IChatClient client = new ChatClientBuilder(
            new OpenAIClient(key).GetChatClient(model ?? "gpt-4o").AsIChatClient())
            .UseFunctionInvocation()
            .Build();

        // <StrictMode>
        AIFunction weatherFunction = AIFunctionFactory.Create(
            (string location, int temperature, bool isRaining) =>
            {
                string weather = isRaining ? "rainy" : "clear";
                return $"Weather in {location}: {temperature}°C and {weather}";
            },
            new AIFunctionFactoryOptions
            {
                Name = "report_weather",
                Description = "Reports the weather for a location with temperature and rain status",
                // Enable strict mode by adding the Strict property (OpenAI only).
                AdditionalProperties = new Dictionary<string, object?>
                {
                    { "Strict", true }
                }
            }
        );
        // </StrictMode>

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
    }
}
