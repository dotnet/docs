using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

// This is a simple mock request to provide the needed function signatures for the snippet code
class MyModelRequest
{
    public required string Request { get; init; }
    public PromptExecutionSettings? Settings { get; init; }

    public static MyModelRequest FromChatHistory(ChatHistory history, PromptExecutionSettings? settings)
    {
        return new MyModelRequest()
        {
            Request = history.Last().Content!,
            Settings = settings
        };
    }

    public static MyModelRequest FromPrompt(string prompt, PromptExecutionSettings? settings)
    {
        return new MyModelRequest()
        {
            Request = prompt,
            Settings = settings
        };
    }
}
