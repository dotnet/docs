---
title: Quickstart - Extend Azure AI using Tools and execute a local Function with .NET 
description: Create a simple chat app using Semantic Kernel or the .NET Azure OpenAI SDK and extend the model to execute a local function.
ms.date: 03/04/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want deploy and use sample code to interact to learn from the sample code how to extend the model using Tools.
---

# Extend Azure AI using Tools and execute a local Function with .NET

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="semantic-kernel"
<!-- markdownlint-enable MD044 -->

Get started with Semantic Kernel by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-35-turbo` model deployed into an Azure OpenAI account, however using Tool to extend the model capabilities it will call a local function. Follow these steps to provision Azure OpenAI and learn how to use Semantic Kernel.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai-sdk"
<!-- markdownlint-enable MD044 -->

Get started with the .NET Azure OpenAI SDK by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-35-turbo` model deployed into an Azure OpenAI account, however using Tool to extend the model capabilities it will call a local function. Follow these steps to provision Azure OpenAI and learn how to use the .NET Azure OpenAI SDK.

:::zone-end

[!INCLUDE [download-alert](includes/prerequisites-and-azure-deploy.md)]

## Try HikerAI Pro sample

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="semantic-kernel"
<!-- markdownlint-enable MD044 -->

1. From a terminal or command prompt, navigate to the `quickstarts\semantic-kernel\04-HikerAIPro` directory.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai-sdk"
<!-- markdownlint-enable MD044 -->

1. From a terminal or command prompt, navigate to the `quickstarts\azure-openai-sdk\04-HikerAIPro` directory.

:::zone-end

2. It's now time to try the console application. Type in the following to run the app:

    ```dotnetcli
    dotnet run
    ```

    If you get an error message the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="semantic-kernel"
<!-- markdownlint-enable MD044 -->

## Understand the code

Our application uses the `Microsoft.SemanticKernel` package, which is available on [NuGet](https://www.nuget.org/packages/Microsoft.SemanticKernel), to send and receive requests to an Azure OpenAI service deployed in Azure.

The entire application is contained within the **Program.cs** file. The first several lines of code loads up secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];
string key = config["AZURE_OPENAI_KEY"];
```

The `Kernel` class facilitates the requests and responses with the help of `AddAzureOpenAIChatCompletion` service.

```csharp
// Create a Kernel containing the Azure OpenAI Chat Completion Service
IKernelBuilder b = Kernel.CreateBuilder();

Kernel kernel = b
    .AddAzureOpenAIChatCompletion(deployment, endpoint, key)
    .Build();
```

```csharp
// Add a new plugin with a local .NET function that should be available to the AI model
// For convenience and clarity of into the code, this standalone local method handles tool call responses. It will fake a call to a weather API and return the current weather for the specified location.
kernel.ImportPluginFromFunctions("WeatherPlugin",
[
    KernelFunctionFactory.CreateFromMethod(([Description("The city, e.g. Montreal, Sidney")] string location, string unit = null) =>
    {
        // Here you would call a weather API to get the weather for the location
        return "Periods of rain or drizzle, 15 C";
    }, "get_current_weather", "Get the current weather in a given location")
]);
```

Once the `kernel` client is created, we provide more context to the model by adding a system prompt. This instructs the model how you'd like it to act during the conversation. Note how the weather is emphasized in the system prompt.

```csharp
ChatHistory chatHistory = new("""
    You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly.
    A good weather is important for a good hike. Only make recommendations if the weather is good or if people insist.
    You introduce yourself when first saying hello. When helping people out, you always ask them 
    for this information to inform the hiking recommendation you provide:

    1. Where they are located
    2. What hiking intensity they are looking for

    You will then provide three suggestions for nearby hikes that vary in length after you get that information. 
    You will also share an interesting fact about the local nature on the hikes when making a recommendation.
    """);
```

Then you can add a user message to the model by using the `AddUserMessage` functon.

To have the model generate a response based off the system prompt and the user request, use the `GetChatMessageContentAsync` function.

```csharp
chatHistory.AddUserMessage("""
    Is the weather is good today for a hike?
    If yes, I live in the greater Montreal area and would like an easy hike. I don't mind driving a bit to get there.
    I don't want the hike to be over 10 miles round trip. I'd consider a point-to-point hike.
    I want the hike to be as isolated as possible. I don't want to see many people.
    I would like it to be as bug free as possible.
    """);

Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");

chatHistory.Add(await service.GetChatMessageContentAsync(chatHistory, new OpenAIPromptExecutionSettings() { MaxTokens = 400 }));
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");
```

Customize the system prompt and user message to see how the model responds to help you find a hike that you'll like.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai-sdk"
<!-- markdownlint-enable MD044 -->

## Understand the code

Our application uses the `Azure.AI.OpenAI` client SDK, which is available on [NuGet](https://www.nuget.org/packages/Azure.AI.OpenAI), to send and receive requests to an Azure OpenAI service deployed in Azure.

The entire application is contained within the **Program.cs** file. The first several lines of code loads up secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
// == Retrieve the local secrets saved during the Azure deployment ==========
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string openAIEndpoint = config["AZURE_OPENAI_ENDPOINT"];
string openAIDeploymentName = config["AZURE_OPENAI_GPT_NAME"];
string openAiKey = config["AZURE_OPENAI_KEY"];

// == Creating the AIClient ==========
var endpoint = new Uri(openAIEndpoint);
var credentials = new AzureKeyCredential(openAiKey);
```

The `OpenAIClient` class facilitates the requests and responses. `ChatCompletionOptions` specifies parameters of how the model will respond. Note how the **Tools** property is used to add the definition.

```csharp
var openAIClient = new OpenAIClient(endpoint, credentials);

var completionOptions = new ChatCompletionsOptions
{
    MaxTokens = 400,
    Temperature = 1f,
    FrequencyPenalty = 0.0f,
    PresencePenalty = 0.0f,
    NucleusSamplingFactor = 0.95f, // Top P
    DeploymentName = openAIDeploymentName,
    Tools = { getWeather }
};
```

The class `ChatCompletionsFunctionToolDefinition` is used to define the local function that will be called by the model.

```csharp
var getWeather = new ChatCompletionsFunctionToolDefinition()
{
    Name = "get_current_weather",
    Description = "Get the current weather in a given location",
    Parameters = BinaryData.FromObjectAsJson(
    new
    {
        Type = "object",
        Properties = new
        {
            Location = new
            {
                Type = "string",
                Description = "The city, e.g. Montreal, Sidney",
            },
            Unit = new
            {
                Type = "string",
                Enum = new[] { "celsius", "fahrenheit" },
            }
        },
        Required = new[] { "location" },
    },
    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
};
```

Once the `OpenAIClient` client is created, we provide more context to the model by adding a system prompt. This instructs the model how you'd like it to act during the conversation. Note how the weather is emphasized in the system prompt.

```csharp
var systemPrompt = 
"""
You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly.
A good weather is important for a good hike. Only make recommendations if the weather is good or if people insist.
You introduce yourself when first saying hello. When helping people out, you always ask them 
for this information to inform the hiking recommendation you provide:

1. Where they are located
2. What hiking intensity they are looking for

You will then provide three suggestions for nearby hikes that vary in length after you get that information. 
You will also share an interesting fact about the local nature on the hikes when making a recommendation.
""";

completionOptions.Messages.Add(new ChatRequestSystemMessage(systemPrompt));
```

Then you can add a user message to the model by using the `ChatRequestUserMessage` class.

For convenience and clarity of into the code, this standalone local method handles tool call responses. It will fake a call to a weather API and return the current weather for the specified location.

```csharp
ChatRequestToolMessage GetToolCallResponseMessage(ChatCompletionsToolCall toolCall)
{
    var functionToolCall = toolCall as ChatCompletionsFunctionToolCall;
    if (functionToolCall?.Name == getWeather.Name)
    {
        string unvalidatedArguments = functionToolCall.Arguments;
        var functionResultData = (object)null;

        // == Here call a weather API to get the weather for specified the location ==========
        functionResultData = "Periods of rain or drizzle, 15 C";

        return new ChatRequestToolMessage(functionResultData.ToString(), toolCall.Id);
    }
    else
    {
        throw new NotImplementedException();
    }
}
```

To have the model generate a response based off the system prompt and the user request, use the `GetChatCompletionsAsync` function.

```csharp
string hikeRequest = """
Is the weather is good today for a hike?
If yes, I live in the greater Montreal area and would like an easy hike. I don't mind driving a bit to get there.
I don't want the hike to be over 10 miles round trip. I'd consider a point-to-point hike.
I want the hike to be as isolated as possible. I don't want to see many people.
I would like it to be as bug free as possible.
""";

Console.WriteLine($"\n\nUser >>> {hikeRequest}");
completionOptions.Messages.Add(new ChatRequestUserMessage(hikeRequest));

response = await openAIClient.GetChatCompletionsAsync(completionOptions);
```

Now, the response need to be examined. If the response includes `ToolCalls`, the method declare previously handle it and continue the conversation. It's important to note that each messages `ChatRequestAssistantMessage` are added to the conversation history. This is important to maintain the context of the conversation.

```csharp
ChatChoice responseChoice = response.Choices[0];
if (responseChoice.FinishReason == CompletionsFinishReason.ToolCalls)
{
    // == Include the FunctionCall message in the conversation history ==========
    completionOptions.Messages.Add(new ChatRequestAssistantMessage(responseChoice.Message));

    // == Add a new tool message for each tool call that is resolved ==========
    foreach (ChatCompletionsToolCall toolCall in responseChoice.Message.ToolCalls)
    {
        var ToolCallMsg = GetToolCallResponseMessage(toolCall);
        completionOptions.Messages.Add(ToolCallMsg);
    }

    // == Retrieve the answer from HikeAI Pro ==========
    response = await openAIClient.GetChatCompletionsAsync(completionOptions);
}

assistantResponse = response.Choices[0].Message;
Console.WriteLine($"\n\nAssistant >>> {assistantResponse.Content}");
```

Customize the system prompt and user message to see how the model responds to help you find a hike that you'll like.

:::zone-end

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

## Next steps

- [Quickstart - Get insight about your data from an .NET Azure AI chat app](quickstart-ai-chat-with-data.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
