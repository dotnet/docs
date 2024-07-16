---
title: Quickstart - Build an AI chat app with .NET
description: Create a simple chat app using Semantic Kernel with OpenAI or Azure OpenAI
ms.date: 07/17/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to AI, I want deploy and use sample code to interact to learn from the sample code.
---

# Build an AI chat app with .NET

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
<!-- markdownlint-enable MD044 -->

Get started with Semantic Kernel by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-3.5-turbo` model. Follow these steps to get access to OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-openai.md)]

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->

Get started with Semantic Kernel by creating a simple .NET 8 console chat application. The application will run locally and connect to the OpenAI `gpt-35-turbo` model deployed into Azure OpenAI. Follow these steps to provision Azure OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-azure-openai.md)]

:::zone-end

## Trying HikerAI sample

<!-- markdownlint-disable MD029 MD044 -->
:::zone target="docs" pivot="openai"

1. From a terminal or command prompt, navigate to the `openai\02-HikerAI` directory.

[!INCLUDE [download-alert](includes/set-openai-secrets.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

1. From a terminal or command prompt, navigate to the `azure-openai\02-HikerAI` directory.

:::zone-end

2. It's now time to try the console application. Type in the following to run the app:

    ```dotnetcli
    dotnet run
    ```

:::zone target="docs" pivot="azure-openai"
    If you get an error message, the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.
:::zone-end

<!-- markdownlint-enable MD029 MD044  -->

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
<!-- markdownlint-enable MD044 -->

## Understanding the code

Our application uses the `Microsoft.SemanticKernel` package, which is available on [NuGet](https://www.nuget.org/packages/Microsoft.SemanticKernel), to send and receive requests to the OpenAI service.

The entire application is contained within the **Program.cs** file. The first several lines of code set configuration values and gets the OpenAI Key that was previously set using the `dotnet user-secrets` command.

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = "gpt-3.5-turbo";
string key = config["OpenAIKey"];
```

The `OpenAIChatCompletionService` service facilitates the requests and responses.

```csharp
// Create the OpenAI Chat Completion Service
OpenAIChatCompletionService service = new(model, key);
```

Once the `OpenAIChatCompletionService` service is created, we provide more context to the model by adding a system prompt. This instructs the model how you'd like it to act during the conversation.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai"
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
:::zone-end

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

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->
## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

:::zone-end

## Next steps

- [Quickstart - Get insight about your data from .NET AI chat app](quickstart-ai-chat-with-data.md)
- [Generate text and conversations with .NET and OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
