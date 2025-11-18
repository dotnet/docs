// <SnippetGetChatClient>
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;

class ArgumentsExample
{
    public static async Task RunManual()
    {
        // <UseAIFunctionArguments>
        Delegate getWeatherDelegate = (AIFunctionArguments args) =>
        {
            // Access named parameters from the arguments dictionary.
            string? location = args.TryGetValue("location", out object? loc) ? loc.ToString() : "Unknown";
            string? units = args.TryGetValue("units", out object? u) ? u.ToString() : "celsius";

            return $"Weather in {location}: 35°{units}";
        };

        // Create the AIFunction.
        AIFunction getWeather = AIFunctionFactory.Create(getWeatherDelegate);

        // Call the function manually.
        var result = await getWeather.InvokeAsync(new AIFunctionArguments
        {
            { "location", "Seattle" },
            { "units", "F" }
        });
        Console.WriteLine($"Function result: {result}");
        // </UseAIFunctionArguments>
    }
    public static async Task UseFICC()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        string endpoint = config["AZURE_OPENAI_ENDPOINT"];
        string apiKey = config["AZURE_OPENAI_API_KEY"];
        string model = config["AZURE_OPENAI_GPT_NAME"];

        FunctionInvokingChatClient client = new FunctionInvokingChatClient(
            new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey))
            .GetChatClient(model).AsIChatClient());

        AIFunctionFactoryOptions functionFactoryOptions = new()
        {
            Name = "get_weather",
            Description = "Gets the current weather",
            AdditionalProperties = new Dictionary<string, object?>
            {
                { "location", "Seattle" },
                { "units", "F" }
            }
        };

        AIFunction getWeather = AIFunctionFactory.Create(() =>
            {
                // Access named parameters from the arguments dictionary.
                AdditionalPropertiesDictionary props = FunctionInvokingChatClient.CurrentContext.Options.AdditionalProperties;

                string location = props["location"].ToString();
                string units = props["units"].ToString();

                return $"Weather in {location}: 35°{units}";
            });

        var chatOptions = new ChatOptions
        {
            Tools = [getWeather],
            AdditionalProperties = new AdditionalPropertiesDictionary { ["location"] = "Seattle", ["units"] = "F" },
        };

        // Prepare chat with service provider.
        List<ChatMessage> chatHistory = [
            new(ChatRole.System, "You're a helpful weather assistant.")
        ];
        chatHistory.Add(new ChatMessage(ChatRole.User, "What's the weather like?"));

        ChatResponse response = await client.GetResponseAsync(chatHistory, chatOptions);
        Console.WriteLine($"Response: {response.Text}");


        //IChatClient client =
        //    new ChatClientBuilder(
        //        new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey))
        //        .GetChatClient(model).AsIChatClient())
        //    .UseFunctionInvocation()
        //    .Build();
    }
}
