using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

class CompletionExamples
{
    public static async void Examples()
    {
        await PromptCompletionExample();
        await ChatCompletionExample();
    }

    static async Task PromptCompletionExample()
    {
        // <prompt-completion>
        // === Retrieve the secrets saved during the Azure deployment ===
        // The config values should remain the same between AOAI and Semantic Kernel
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var endpoint = config["AZURE_OPENAI_ENDPOINT"];
        var deployment = config["AZURE_OPENAI_GPT_NAME"];
        var key = config["AZURE_OPENAI_KEY"];

        var executionSettings = new OpenAIPromptExecutionSettings
        {
            MaxTokens = 400
            // Additional options, e.g., Temperature, ResultsPerPrompt, etc.
        };

        // === Create a Kernel containing the AOAI Chat Completion Service ===
        var kernel = Kernel.CreateBuilder()
            .AddAzureOpenAIChatCompletion(deployment, endpoint, key)
            .Build();

        // === Define the prompt ===
        var prompt = "Please list three services offered by Azure";
        Console.WriteLine($"Prompt: {prompt}");

        // === Get the response and display it ===
        var response = await kernel.InvokePromptAsync<string>(prompt, new(executionSettings));
        Console.WriteLine($"Output: {response}");
        // </prompt-completion>
    }

    static async Task ChatCompletionExample()
    {
        // <chat-completion>
        // === Retrieve the secrets saved during the Azure deployment ===
        // The config values should remain the same between AOAI and Semantic Kernel
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var endpoint = config["AZURE_OPENAI_ENDPOINT"];
        var deployment = config["AZURE_OPENAI_GPT_NAME"];
        var key = config["AZURE_OPENAI_KEY"];

        var executionSettings = new OpenAIPromptExecutionSettings
        {
            MaxTokens = 400,
            // Additional options, e.g., Temperature, ResultsPerPrompt, etc.
        };

        // === Create the AOAI Chat Completion Service ===
        var service = new AzureOpenAIChatCompletionService(deployment, endpoint, key);

        // === Providing context for AI models via the chat history, initialized with a system message ===
        var systemMessage =
        """
        You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly. 
        You introduce yourself when first saying hello. When helping people out, you always ask them 
        for this information to inform the hiking recommendation you provide:

        1. Where they are located
        2. What hiking intensity they are looking for

        You will then provide three suggestions for nearby hikes that vary in length after you get that information. 
        You will also share an interesting fact about the local nature on the hikes when making a recommendation.
        """;

        Console.WriteLine($"System Prompt: {systemMessage}");
        var chatHistory = new ChatHistory(systemMessage);

        // === Starting the conversation with a user message ===
        var userGreeting =
        """
        Hi! 
        Apparently you can help me find a hike that I will like?
        """;

        Console.WriteLine($"User: {userGreeting}");
        chatHistory.AddUserMessage(userGreeting);

        // === Get the first response, display it, and add it to the chat history ===
        var assistantResponse = await service.GetChatMessageContentAsync(chatHistory, executionSettings);
        Console.WriteLine($"Assistant: {assistantResponse.Content}");
        chatHistory.Add(assistantResponse);

        // === Providing the user's request ===
        var hikeRequest =
        """
        I live in the greater Montreal area and would like an easy hike. I don't mind driving a bit to get there.
        I don't want the hike to be over 10 miles round trip. I'd consider a point-to-point hike.
        I want the hike to be as isolated as possible. I don't want to see many people.
        I would like it to be as bug free as possible.
        """;

        Console.WriteLine($"User: {hikeRequest}");
        chatHistory.AddUserMessage(hikeRequest);

        // === Get the next response and display it ===
        assistantResponse = await service.GetChatMessageContentAsync(chatHistory, executionSettings);
        Console.WriteLine($"Assistant: ${assistantResponse.Content}");
        // </chat-completion>
    }
}