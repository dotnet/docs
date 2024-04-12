using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.TextGeneration;

class LocalModelExamples
{
    public static async Task Examples()
    {
        AddTextGenerationServiceExample();
        AddChatCompletionServiceExample();
        await UseTextGenerationServiceExample();
        await UseChatCompletionServiceExample();
    }

    static Kernel AddTextGenerationServiceExample()
    {
        // <addTextService>
        IKernelBuilder builder = Kernel.CreateBuilder();

        // Add your text generation service as a singleton instance
        var service = new MyTextGenerationService();
        builder.Services.AddKeyedSingleton<ITextGenerationService>("myTextService1", service);

        // Alternatively, add your text generation service as a factory method
        builder.Services.AddKeyedSingleton<ITextGenerationService>("myTextService2", (_, _) => new MyTextGenerationService());

        // Add any other Kernel services or configurations
        // ...
        Kernel kernel = builder.Build();
        // </addTextService>

        return builder.Build();
    }

    static Kernel AddChatCompletionServiceExample()
    {
        // <addChatService>
        IKernelBuilder builder = Kernel.CreateBuilder();

        // Add your chat completion service as a singleton instance
        var service = new MyChatCompletionService();
        builder.Services.AddKeyedSingleton<IChatCompletionService>("myChatService1", service);

        // Alternatively, add your chat completion service as a factory method
        builder.Services.AddKeyedSingleton<IChatCompletionService>("myChatService2", (_, _) => new MyChatCompletionService());

        // Add any other Kernel services or configurations
        // ...
        Kernel kernel = builder.Build();
        // </addChatService>

        return kernel;
    }

    static async Task UseTextGenerationServiceExample()
    {
        IKernelBuilder builder = Kernel.CreateBuilder();
        builder.Services.AddKeyedSingleton<ITextGenerationService>("myTextService", new MyTextGenerationService());
        Kernel kernel = builder.Build();

        // <useTextService>
        var executionSettings = new PromptExecutionSettings
        {
            // Add execution settings, such as the ModelID and ExtensionData
        };

        // Send a prompt to your model directly through the Kernel
        string prompt = "Please list three services offered by Azure";
        string? response = await kernel.InvokePromptAsync<string>(prompt);
        Console.WriteLine($"Output: {response}");

        // Alteratively, send a prompt to your model through the text generation service
        ITextGenerationService textService = kernel.GetRequiredService<ITextGenerationService>();
        TextContent responseContents = await textService.GetTextContentAsync(prompt, executionSettings);
        Console.WriteLine($"Output: {responseContents.Text}");
        // </useTextService>
    }

    static async Task UseChatCompletionServiceExample()
    {
        IKernelBuilder builder = Kernel.CreateBuilder();
        builder.Services.AddKeyedSingleton<IChatCompletionService>("myChatService", new MyChatCompletionService());
        Kernel kernel = builder.Build();

        // <useChatService>
        var executionSettings = new PromptExecutionSettings
        {
            // Add execution settings, such as the ModelID and ExtensionData
        };

        // Initialize a chat history with your initial system message
        string systemMessage = "<the initial system message for your chat history>";
        Console.WriteLine($"System Prompt: {systemMessage}");
        var chatHistory = new ChatHistory(systemMessage);

        // Add the user's input to your chat history
        string userGreeting = "<the user's initial greeting message>";
        Console.WriteLine($"User: {userGreeting}");
        chatHistory.AddUserMessage(userGreeting);

        // Send the chat history to your model through the chat completion service
        // Add the model's response to the chat history
        IChatCompletionService service = kernel.GetRequiredService<IChatCompletionService>();
        ChatMessageContent response = await service.GetChatMessageContentAsync(chatHistory, executionSettings);
        Console.WriteLine($"Assistant: {response.Content}");
        chatHistory.Add(response);
        // </useChatService>
    }
}