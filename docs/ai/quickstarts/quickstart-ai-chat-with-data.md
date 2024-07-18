---
title: Quickstart - Get insight about your data from a .NET AI chat app
description: Create a simple chat app using your data, Semantic Kernel, and OpenAI.
ms.date: 07/17/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to AI development with OpenAI, I want deploy and use sample code and data to interact to learn from the sample code.
---

# Get insight about your data from a .NET AI chat app

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
<!-- markdownlint-enable MD044 -->

Get started with AI development, using the `gpt-3.5-turbo` model from a simple .NET 8.0 console application. Use the AI model to get analytics and information about your previous hikes. It consists of a simple console application, running locally, that will read the file `hikes.md` and send request to the OpenAI service and provide the result in the console. Follow these steps to get access to OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-openai.md)]
:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->

Get started with AI development, using the `gpt-35-turbo` model from a simple .NET 8.0 console application. Use the AI model to get analytics and information about your previous hikes. It consists of a simple console application, running locally, that will read the file `hikes.md` and send request to an Azure OpenAI service deployed in your Azure subscription and provide the result in the console. Follow these steps to provision Azure OpenAI and learn how to use the .NET Azure OpenAI SDK.

[!INCLUDE [download-alert](includes/prerequisites-azure-openai.md)]
:::zone-end

## Try "Chatting About My Previous Hikes" sample

<!-- markdownlint-disable MD029 MD044 -->
:::zone target="docs" pivot="openai"

1. From a terminal or command prompt, navigate to the `openai\03-ChattingAboutMyHikes` directory.

    [!INCLUDE [download-alert](includes/set-openai-secrets.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

1. From a terminal or command prompt, navigate to the `azure-openai\03-ChattingAboutMyHikes` directory.

:::zone-end

2. It's now time to try the console application. Type in the following to run the app:

    ```dotnetcli
    dotnet run
    ```

    :::zone target="docs" pivot="azure-openai"
    If you get an error message the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.
    :::zone-end
<!-- markdownlint-enable MD029 MD044  -->

## Explore the code

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
<!-- markdownlint-enable MD044 -->
The application uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to an OpenAI service.

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

Once the `OpenAIChatCompletionService` client is created, the app reads the content of the file `hikes.md` and uses it to provide more context to the model by adding a system prompt. This influences model behavior and the generated completions during the conversation.
:::zone-end

:::zone target="docs" pivot="azure-openai"
The application uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to an Azure OpenAI service deployed in Azure.

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

Once the `AzureOpenAIChatCompletionService` client is created, we read the content of the file `hikes.md` and use it to provide more context to the model by adding a system prompt. This instructs the model how you'd like it to act during the conversation.
:::zone-end

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

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

:::zone-end

## Next steps

- [Quickstart - Generate images using AI with .NET](quickstart-openai-generate-images.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
