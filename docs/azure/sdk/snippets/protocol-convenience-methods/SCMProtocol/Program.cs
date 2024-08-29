﻿using OpenAI.Chat;
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

// Call the protocol method
ClientResult result = client.CompleteChat(
    content,
    new RequestOptions
    {
        ErrorOptions = ClientErrorBehaviors.NoThrow,
    });

PipelineResponse response = result.GetRawResponse();

// Any non-200 response code from CompleteChat endpoint isn't considered a success response.
if (response.Status != 200)
{
    throw new ClientResultException(response);
}

BinaryData output = result.GetRawResponse().Content;
using JsonDocument outputAsJson = JsonDocument.Parse(output);
JsonElement message = outputAsJson.RootElement
    .GetProperty("choices"u8)[0]
    .GetProperty("message"u8);

// Display the results
Console.WriteLine($@"[{message.GetProperty("role"u8)}]:
    {message.GetProperty("content"u8)}");
