using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

OpenAIClient client = new("your-openai-api-key");
ChatClient chatClient = client.GetChatClient("gpt-4");

ClientResult<ChatCompletion> completion
    = chatClient.CompleteChat("What is Azure?");

Console.WriteLine($"{completion.Value.Role}: {completion.Value.Content}");