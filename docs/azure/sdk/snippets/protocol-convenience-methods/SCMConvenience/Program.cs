using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

// Create the client
OpenAIClient client = new("your-openai-api-key");
ChatClient chatClient = client.GetChatClient("gpt-4");

// Call the convenience method
ChatCompletion completion
    = chatClient.CompleteChat("What is Azure?");

// Display the results
Console.WriteLine($"{completion.Role}: {completion.Content}");