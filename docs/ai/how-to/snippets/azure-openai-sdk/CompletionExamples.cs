
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;

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
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var openAIEndpoint = config["AZURE_OPENAI_ENDPOINT"];
        var openAIDeploymentName = config["AZURE_OPENAI_GPT_NAME"];
        var openAiKey = config["AZURE_OPENAI_KEY"];


        // === Creating the OpenAIClient ===
        var endpoint = new Uri(openAIEndpoint);
        var credentials = new AzureKeyCredential(openAiKey);
        var openAIClient = new OpenAIClient(endpoint, credentials);

        var completionOptions = new ChatCompletionsOptions
        {
            DeploymentName = openAIDeploymentName
            // Additional options, e.g., MaxTokens, Temperature, etc.
        };

        // === Specify the prompt as a user message ===
        var userRequest = "Please list three services offered by Azure";
        completionOptions.Messages.Add(new ChatRequestUserMessage(userRequest));
        Console.WriteLine($"Prompt: {userRequest}");

        // === Get the response and display it ===

        ChatCompletions response = await openAIClient.GetChatCompletionsAsync(completionOptions);
        var assistantResponse = response.Choices[0].Message;
        Console.WriteLine($"Output: {assistantResponse.Content}");
        // </prompt-completion>
    }

    static async Task ChatCompletionExample()
    {
        // <chat-completion>
        // === Retrieve the secrets saved during the Azure deployment ===
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var openAIEndpoint = config["AZURE_OPENAI_ENDPOINT"];
        var openAIDeploymentName = config["AZURE_OPENAI_GPT_NAME"];
        var openAiKey = config["AZURE_OPENAI_KEY"];


        // == Creating the OpenAIClient ==========
        var endpoint = new Uri(openAIEndpoint);
        var credentials = new AzureKeyCredential(openAiKey);
        var openAIClient = new OpenAIClient(endpoint, credentials);

        var completionOptions = new ChatCompletionsOptions
        {
            DeploymentName = openAIDeploymentName
            // Additional options, e.g., MaxTokens, Temperature, etc.
        };

        // === Providing context for the AI model as a system message ===
        var systemPrompt =
        """
        You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly. 
        You introduce yourself when first saying hello. When helping people out, you always ask them 
        for this information to inform the hiking recommendation you provide:

        1. Where they are located
        2. What hiking intensity they are looking for

        You will then provide three suggestions for nearby hikes that vary in length after you get that information. 
        You will also share an interesting fact about the local nature on the hikes when making a recommendation.
        """;

        Console.WriteLine($"System Prompt: {systemPrompt}");
        completionOptions.Messages.Add(new ChatRequestSystemMessage(systemPrompt));

        // === Starting the conversation with a user message ===
        var userGreeting =
        """
        Hi! 
        Apparently you can help me find a hike that I will like?
        """;

        Console.WriteLine($"User: {userGreeting}");
        completionOptions.Messages.Add(new ChatRequestUserMessage(userGreeting));

        // === Get the first response, display it, and add it to the message list
        ChatCompletions response = await openAIClient.GetChatCompletionsAsync(completionOptions);
        var assistantResponse = response.Choices[0].Message;

        Console.WriteLine($"Assistant: {assistantResponse.Content}");
        completionOptions.Messages.Add(new ChatRequestAssistantMessage(assistantResponse.Content));


        // === Providing the user's request ===
        var hikeRequest =
        """
        I live in the greater Montreal area and would like an easy hike. I don't mind driving a bit to get there.
        I don't want the hike to be over 10 miles round trip. I'd consider a point-to-point hike.
        I want the hike to be as isolated as possible. I don't want to see many people.
        I would like it to be as bug free as possible.
        """;

        Console.WriteLine($"User: {hikeRequest}");
        completionOptions.Messages.Add(new ChatRequestUserMessage(hikeRequest));

        // === Get the next response and display it ===
        response = await openAIClient.GetChatCompletionsAsync(completionOptions);
        assistantResponse = response.Choices[0].Message;

        Console.WriteLine($"Assistant: {assistantResponse.Content}");
        // </chat-completion>
    }
}
