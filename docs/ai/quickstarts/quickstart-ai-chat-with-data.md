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

Get started with AI development using a .NET 8 console app to connect to an OpenAI `gpt-3.5-turbo` model. You'll connect to the AI model using [Semantic Kernel](../semantic-kernel-dotnet-overview.md) to analyze hiking data and provide insights.

[!INCLUDE [download-alert](includes/prerequisites-openai.md)]
:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->

Get started with AI development using a .NET 8 console app to connect to an OpenAI `gpt-3.5-turbo` model deployed on Azure. You'll connect to the AI model using [Semantic Kernel](../semantic-kernel-dotnet-overview.md) to analyze hiking data and provide insights.

[!INCLUDE [download-alert](includes/prerequisites-azure-openai.md)]
:::zone-end

## Get the sample project

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

:::zone target="docs" pivot="azure-openai"

## Create the Azure OpenAI service

# [Azure Developer CLI](#tab/azd)

[!INCLUDE [deploy-azd](includes/deploy-azd.md)]

# [Azure CLI](#tab/azure-cli)

1. To provision an Azure OpenAI service and model using the Azure CLI, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=cli) article.

1. From a terminal or command prompt, navigate to the  `openai\03-ChattingAboutMyHikes` directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>

# [Azure Portal](#tab/azure-portal)

1. To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article.

1. From a terminal or command prompt, navigate to the  `openai\03-ChattingAboutMyHikes` directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>

---

:::zone-end

## Try the hiking chat sample

<!-- markdownlint-disable MD029 MD044 -->
:::zone target="docs" pivot="openai"

1. From a terminal or command prompt, navigate to the `openai\03-ChattingAboutMyHikes` directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>
    ```

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

:::zone-end

:::zone target="docs" pivot="azure-openai"

1. From a terminal or command prompt, navigate to the `azure-openai\02-HikerAI` directory.

2. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    > [!TIP]
    > If you get an error message, the Azure OpenAI resources might not have finished deploying. Wait a couple of minutes and try again.

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

Once the `OpenAIChatCompletionService` client is created, the app reads the content of the file `hikes.md` and uses it to provide more context to the model by adding a system prompt. This influences model behavior and the generated completions during the conversation.
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

The following code adds a user prompt to the model using the `AddUserMessage` function. The `GetChatMessageContentAsync` function instructs the model to generate a response based off the system and user prompts.

```csharp
// Start the conversation
chatHistory.AddUserMessage("Hi!");
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");

chatHistory.Add(
    await service.GetChatMessageContentAsync(
        chatHistory,
        new OpenAIPromptExecutionSettings()
        { 
            MaxTokens = 400 
        }));
Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");
```

The app adds the response from the model to the `chatHistory` to maintain the chat history or context.

```csharp
// Continue the conversation with a question.
chatHistory.AddUserMessage(
    "I would like to know the ratio of the hikes I've done in Canada compared to other countries.");

Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");

chatHistory.Add(await service.GetChatMessageContentAsync(
    chatHistory,
    new OpenAIPromptExecutionSettings()
    { 
        MaxTokens = 400 
    }));

Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");
```

Customize the system or user prompts to provide different questions and context:

- How many times did I hike when it was raining?
- How many times did I hike in 2021?

The model generates a relevant response to each prompt based on your inputs.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

[!INCLUDE [troubleshoot](includes/troubleshoot.md)]

:::zone-end

## Next steps

- [Quickstart - Generate images using AI with .NET](quickstart-openai-generate-images.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
