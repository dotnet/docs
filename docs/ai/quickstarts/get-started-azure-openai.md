---
title: Quickstart - Build an Azure AI chat app with .NET
description: Create a simple chat app using Semantic Kernel or the .NET Azure OpenAI SDK.
ms.date: 03/04/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want deploy and use sample code to interact to learn from the sample code.
---

# Build an Azure AI chat app with .NET

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="semantic-kernel"
<!-- markdownlint-enable MD044 -->

Get started with Semantic Kernel by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-35-turbo` model deployed into an Azure OpenAI account. Follow these steps to provision Azure OpenAI and learn how to use Semantic Kernel.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai-sdk"
<!-- markdownlint-enable MD044 -->

Get started with the .NET Azure OpenAI SDK by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-35-turbo` model deployed into an Azure OpenAI account. Follow these steps to provision Azure OpenAI and learn how to use the .NET Azure OpenAI SDK.

:::zone-end

[!INCLUDE [download-alert](includes/prerequisites-and-azure-deploy.md)]

## Trying HikerAI sample

<!-- markdownlint-disable MD029 MD044 -->
:::zone target="docs" pivot="semantic-kernel"

1. From a terminal or command prompt, navigate to the `semantic-kernel\02-HikerAI` directory.

:::zone-end

:::zone target="docs" pivot="azure-openai-sdk"

1. From a terminal or command prompt, navigate to the `azure-openai-sdk\02-HikerAI` directory.

:::zone-end


2. It's now time to try the console application. Type in the following to run the app:

    ```dotnetcli
    dotnet run
    ```

    If you get an error message the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.
<!-- markdownlint-enable MD029 MD044  -->

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="semantic-kernel"
<!-- markdownlint-enable MD044 -->

## Understanding the code

Our application uses the `Microsoft.SemanticKernel` package, which is available on [NuGet](https://www.nuget.org/packages/Microsoft.SemanticKernel), to send and receive requests to an Azure OpenAI service deployed in Azure.

The entire application is contained within the **Program.cs** file. The first several lines of code loads up secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
// == Retrieve the local secrets saved during the Azure deployment ==========
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];
string key = config["AZURE_OPENAI_KEY"];
```

The `AzureOpenAIChatCompletionService` service facilitates the requests and responses.

```csharp
// == Create the Azure OpenAI Chat Completion Service  ==========
AzureOpenAIChatCompletionService service = new(deployment, endpoint, key);
```

Once the `AzureOpenAIChatCompletionService` service is created, we provide more context to the model by adding a system prompt. This instructs the model how you'd like it to act during the conversation.

```csharp
// Start the conversation with context for the AI model
ChatHistory chatHistory = new("""
    You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly. 
    You introduce yourself when first saying hello. When helping people out, you always ask them 
    for this information to inform the hiking recommendation you provide:

    1. Where they are located
    2. What hiking intensity they are looking for

    You will then provide three suggestions for nearby hikes that vary in length after you get that information. 
    You will also share an interesting fact about the local nature on the hikes when making a recommendation.
    """);
```

Then you can add a user message to the model by using the `AddUserMessage` function.

To have the model generate a response based off the system prompt and the user request, use the `GetChatMessageContentAsync` function.

```csharp

// Add user message to chat history
chatHistory.AddUserMessage("Hi! Apparently you can help me find a hike that I will like?");

// Print User Message to console
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");

// Get response
var response = await service.GetChatMessageContentAsync(chatHistory, new OpenAIPromptExecutionSettings() { MaxTokens = 400 });
```

To maintain the chat history, make sure you add the response from the model.

```csharp
// Add response to chat history
chatHistory.Add(response);

// Print Response to console
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");
```

Customize the system prompt and user message to see how the model responds to help you find a hike that you'll like.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai-sdk"
<!-- markdownlint-enable MD044 -->

## Understanding the code

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

Once the `OpenAIClient` client is created, we provide more context to the model by adding a system prompt. This instructs the model how you'd like it to act during the conversation.

```csharp
var systemPrompt = 
"""
You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly. 
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

To have the model generate a response based off the system prompt and the user request, use the `GetChatCompletionsAsync` function.

```csharp
string userGreeting = """
Hi! 
Apparently you can help me find a hike that I will like?
""";

completionOptions.Messages.Add(new ChatRequestUserMessage(userGreeting));
Console.WriteLine($"\n\nUser >>> {userGreeting}");

ChatCompletions response = await openAIClient.GetChatCompletionsAsync(completionOptions);
ChatResponseMessage assistantResponse = response.Choices[0].Message;
Console.WriteLine($"\n\nAI >>> {assistantResponse.Content}");
completionOptions.Messages.Add(new ChatRequestAssisstantMessage(assistantResponse.Content)); 
```

To maintain the chat history or context, make sure you add the response from the model as a `ChatRequestAssistantMessage`.

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
