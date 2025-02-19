using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = config["ModelName"];
string key = config["OpenAIKey"];

IChatClient client =
    new ChatClientBuilder()
        .UseFunctionInvocation()
        .Use(
            new OpenAIClient(key)
                .AsChatClient(model));

// Add a new plugin with a local .NET function that should be available to the AI model
var chatOptions = new ChatOptions
{
    Tools = [AIFunctionFactory.Create((string location, string unit) =>
    {
        // Here you would call a weather API to get the weather for the location
        return "Periods of rain or drizzle, 15 C";
    },
    "get_current_weather",
    "Get the current weather in a given location")]
};

// System prompt to provide context
List<ChatMessage> chatHistory = [new(ChatRole.System, """
    You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly.
    """)];

// Weather conversation relevant to the registered function
chatHistory.Add(new ChatMessage(ChatRole.User,
    "I live in Montreal and I'm looking for a moderate intensity hike. What's the current weather like? "));
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last()}");

var response = await client.GetResponseAsync(chatHistory, chatOptions);
chatHistory.Add(new ChatMessage(ChatRole.Assistant, response.Message.Contents));
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last()}");
