using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

// Create the client
ChatClient client = new(
    model: "gpt-4o-mini",
    credential: Environment.GetEnvironmentVariable("OPENAI_API_KEY")!);

// Create the request content
BinaryData input = BinaryData.FromBytes("""
    {
        "model": "gpt-4o-mini",
        "messages": [
           {
               "role": "user",
               "content": "What is Microsoft Azure?"
           }
        ]
    }
    """u8.ToArray());
using BinaryContent content = BinaryContent.Create(input);

var requestOptions = new RequestOptions();

requestOptions.AddHeader("CustomHeader", "CustomHeaderValue");
requestOptions.ErrorOptions = ClientErrorBehaviors.NoThrow;

// Call the protocol method
ClientResult result = client.CompleteChat(
    content,
    requestOptions
);

PipelineResponse response = result.GetRawResponse();

// Any non-200 response code from CompleteChat endpoint isn't considered a success response.
if (response.Status != 200)
{
    throw new ClientResultException(response);
}

using JsonDocument output = JsonDocument.Parse(response.Content);
JsonElement message = output.RootElement
    .GetProperty("choices"u8)[0]
    .GetProperty("message"u8);

// Display the results
Console.WriteLine($@"[{message.GetProperty("role"u8)}]:
    {message.GetProperty("content"u8)}");
