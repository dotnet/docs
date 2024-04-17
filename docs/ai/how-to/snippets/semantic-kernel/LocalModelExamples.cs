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

        return kernel;
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
            ModelId = "MyModelId",
            ExtensionData = new Dictionary<string, object> { { "MaxTokens", 500 } }
        };

        // Send a prompt to your model directly through the Kernel
        // The Kernel response will be null if the model can't be reached
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
            ModelId = "MyModelId",
            ExtensionData = new Dictionary<string, object> { { "MaxTokens", 500 } }
        };

        // Send a string representation of the chat history to your model directly through the Kernel
        // This uses a special syntax to denote the role for each message
        // For more information on this syntax see https://learn.microsoft.com/en-us/semantic-kernel/prompts/your-first-prompt?tabs=Csharp#6-using-message-roles-in-chat-completion-prompts
        string prompt = """
        <message role="system">the initial system message for your chat history</message>
        <message role="user">the user's initial message</message>
        """;

        string? response = await kernel.InvokePromptAsync<string>(prompt);
        Console.WriteLine($"Output: {response}");

        // Alteratively, send a prompt to your model through the chat completion service
        // First, initialize a chat history with your initial system message
        string systemMessage = "<the initial system message for your chat history>";
        Console.WriteLine($"System Prompt: {systemMessage}");
        var chatHistory = new ChatHistory(systemMessage);

        // Add the user's input to your chat history
        string userRequest = "<the user's initial message>";
        Console.WriteLine($"User: {userRequest}");
        chatHistory.AddUserMessage(userRequest);

        // Get the models response and add it to the chat history
        IChatCompletionService service = kernel.GetRequiredService<IChatCompletionService>();
        ChatMessageContent responseMessage = await service.GetChatMessageContentAsync(chatHistory, executionSettings);
        Console.WriteLine($"Assistant: {responseMessage.Content}");
        chatHistory.Add(responseMessage);

        // Continue sending and receiving messages between the user and model
        // ...
        // </useChatService>
    }
}