using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

// Create the client
OpenAIClient client = new("<your-openai-api-key>");
ChatClient chatClient = client.GetChatClient("gpt-4");

// Create the request content
BinaryData input = BinaryData.FromBytes("""
    {  
        "model": "gpt-4o",
        "messages": [
           {
               "role": "user",
               "content": "What is Microsoft Azure?."
           }
        ]
    }
    """u8.ToArray());
using BinaryContent content = BinaryContent.Create(input);

// Call the protocol method
ClientResult result = chatClient.CompleteChat(
        content,
        new RequestOptions()
        {
            ErrorOptions = ClientErrorBehaviors.NoThrow
        });

// Display the results
BinaryData output = result.GetRawResponse().Content;

using JsonDocument outputAsJson = JsonDocument.Parse(output);
string message = outputAsJson.RootElement
    .GetProperty("choices"u8)[0]
    .GetProperty("message"u8)
    .GetProperty("content"u8)
    .GetString();

Console.WriteLine(message);