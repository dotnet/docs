---
title: Quickstart - Get insight about your data from an .NET Azure AI chat app
description: Create a simple chat app using your data and Semantic Kernel or the .NET Azure OpenAI SDK.
ms.date: 03/04/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want deploy and use sample code and data to interact to learn from the sample code.
---

# Get insight about your data from an .NET Azure AI chat app

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="semantic-kernel"
<!-- markdownlint-enable MD044 -->

Get started with Semantic Kernel and the `gpt-35-turbo` model, from a simple .NET 8.0 console application. Use the AI model to get analytics and information about your previous hikes. It consists of a simple console application, running locally, that will read the file `hikes.md` and send request to an Azure OpenAI service deployed in your Azure subscription and provide the result in the console. Follow these steps to provision Azure OpenAI and learn how to use Semantic Kernel.
:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai-sdk"
<!-- markdownlint-enable MD044 -->

Get started with the .NET Azure OpenAI with a `gpt-35-turbo` model, from a simple .NET 8.0 console application. Use the AI model to get analytics and information about your previous hikes. It consists of a simple console application, running locally, that will read the file `hikes.md` and send request to an Azure OpenAI service deployed in your Azure subscription and provide the result in the console. Follow these steps to provision Azure OpenAI and learn how to use the .NET Azure OpenAI SDK.

:::zone-end

[!INCLUDE [download-alert](includes/prerequisites-and-azure-deploy.md)]

## Try "Chatting About My Previous Hikes" sample

1. From a terminal or command prompt, navigate to the `03-ChattingAboutMyHikes` directory.
2. It's now time to try the console application. Type in the following to run the app:

    ```dotnetcli
    dotnet run
    ```

    If you get an error message the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="semantic-kernel"
<!-- markdownlint-enable MD044 -->

## Explore the code

Our application uses the `Microsoft.SemanticKernel` package, which is available on [NuGet](https://www.nuget.org/packages/Microsoft.SemanticKernel), to send and receive requests to an Azure OpenAI service deployed in Azure.

The `AzureOpenAIChatCompletionService` service facilitates the requests and responses.

```csharp
// == Create the Azure OpenAI Chat Completion Service  ==========
AzureOpenAIChatCompletionService service = new(deployment, endpoint, key);
```

The entire application is contained within the **Program.cs** file. The first several lines of code loads up secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
// == Retrieve the local secrets saved during the Azure deployment ==========
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];
string key = config["AZURE_OPENAI_KEY"];
```

Once the `AzureOpenAIChatCompletionService` client is created, we read the content of the file `hikes.md` and use it to provide more context to the model by adding a system prompt. This instructs the model how you'd like it to act during the conversation.

```csharp
// Provide context for the AI model
ChatHistory chatHistory = new($"""
    You are upbeat and friendly. You introduce yourself when first saying hello. 
    Provide a short answer only based on the user hiking records below:  

    {File.ReadAllText("hikes.md")}
    """);
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");
```

Then you can add a user message to the model by using the `AddUserMessage` function.

To have the model generate a response based off the system prompt and the user request, use the `GetChatMessageContentAsync` function.

```csharp
// Start the conversation
chatHistory.AddUserMessage("Hi!");
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");

chatHistory.Add(await service.GetChatMessageContentAsync(chatHistory, new OpenAIPromptExecutionSettings() { MaxTokens = 400 }));
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");
```

To maintain the chat history or context, make sure you add the response from the model to the `chatHistory`. It's time to make our user request about our data again using the `AddUserMessage` and `GetChatMessageContentAsync` function.

```csharp
// Continue the conversation with a question.
chatHistory.AddUserMessage("I would like to know the ratio of the hikes I've done in Canada compared to other countries.");
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");

chatHistory.Add(await service.GetChatMessageContentAsync(chatHistory, new OpenAIPromptExecutionSettings() { MaxTokens = 400 }));
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");
```

Customize the system prompt and change the request, asking for different questions (ex: How many times did you hiked when it was raining? How many times did you hiked in 2021? etc.) to see how the model responds.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai-sdk"
<!-- markdownlint-enable MD044 -->

## Explore the code

Our application uses the `Azure.AI.OpenAI` client SDK, which is available on [NuGet](https://www.nuget.org/packages/Azure.AI.OpenAI), to send and receive requests to an Azure OpenAI service deployed in Azure.

The `OpenAIClient` class facilitates the requests and responses. `ChatCompletionOptions` specifies parameters of how the model will respond.

```csharp
var openAIClient = new OpenAIClient(endpoint, credentials);

var completionOptions = new ChatCompletionsOptions
{
    MaxTokens = 400,
    Temperature = 1f,
    FrequencyPenalty = 0.0f,
    PresencePenalty = 0.0f,
    NucleusSamplingFactor = 0.95f, // Top P
    DeploymentName = openAIDeploymentName
};
```

The entire application is contained within the **Program.cs** file. The first several lines of code loads up secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
// == Retrieve the local secrets saved during the Azure deployment ==========
var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string openAIEndpoint = config["AZURE_OPENAI_ENDPOINT"];
string openAIDeploymentName = config["AZURE_OPENAI_GPT_NAME"];
string openAiKey = config["AZURE_OPENAI_KEY"];

// == Creating the AIClient ==========
var endpoint = new Uri(openAIEndpoint);
var credentials = new AzureKeyCredential(openAiKey);
```

Once the `OpenAIClient` client is created, we read the content of the file `hikes.md` and use it to provide more context to the model by adding a system prompt. This instructs the model how you'd like it to act during the conversation.

```csharp
var systemPrompt = 
"""
You are upbeat and friendly. You introduce yourself when first saying hello. 
Provide a short answer only based on the user hiking records below:  

""" + markdown;

completionOptions.Messages.Add(new ChatRequestSystemMessage(systemPrompt));
```

Then you can add a user message to the model by using the `ChatRequestUserMessage` class.

To have the model generate a response based off the system prompt and the user request, use the `GetChatCompletionsAsync` function.

```csharp
string userGreeting = """
Hi! 
""";

completionOptions.Messages.Add(new ChatRequestUserMessage(userGreeting));
Console.WriteLine($"\n\nUser >>> {userGreeting}");

ChatCompletions response = await openAIClient.GetChatCompletionsAsync(completionOptions);
ChatResponseMessage assistantResponse = response.Choices[0].Message;
Console.WriteLine($"\n\nAI >>> {assistantResponse.Content}");
completionOptions.Messages.Add(new ChatRequestAssisstantMessage(assistantResponse.Content)); 
```

To maintain the chat history or context, make sure you add the response from the model as a `ChatRequestAssistantMessage`. It's time to make our user request about our data again using the `ChatRequestUserMessage` and `GetChatCompletionsAsync` function.

```csharp
var hikeRequest = 
"""
I would like to know the ration of hike I did in Canada compare to hikes done in other countries.
""";

Console.WriteLine($"\n\nUser >>> {hikeRequest}");
completionOptions.Messages.Add(new ChatRequestUserMessage(hikeRequest));
response = await openAIClient.GetChatCompletionsAsync(completionOptions);
```

Customize the system prompt and change the request, asking for different questions (ex: How many times did you hiked when it was raining? How many times did you hiked in 2021? etc.) to see how the model responds.

:::zone-end

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

## Next steps

- [Quickstart - Generate images using Azure AI with .NET](quickstart-openai-generate-images.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
