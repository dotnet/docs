---
title: Quickstart - Summarize text using an AI chat app with .NET
description: Create a simple chat app using OpenAI and the Semantic Kernel SDK to summarize a text.
ms.date: 07/17/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Summarize text using AI chat app with .NET

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
<!-- markdownlint-enable MD044 -->

Get started with AI by creating a simple .NET 8 console chat application to summarize text. The application will run locally and use the OpenAI `gpt-3.5-turbo` model. Follow these steps to get access to OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-openai.md)]

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->

Get started with AI by creating a simple .NET 8 console chat application to summarize text. The application will run locally and connect to the OpenAI `gpt-35-turbo` model deployed into Azure OpenAI. Follow these steps to provision Azure OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-azure-openai.md)]

:::zone-end

## Trying Hiking Benefits Summary sample

<!-- markdownlint-disable MD029 MD044 -->
:::zone target="docs" pivot="openai"

1. From a terminal or command prompt, navigate to the `openai\01-HikeBenefitsSummary` directory.

    [!INCLUDE [download-alert](includes/set-openai-secrets.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

1. From a terminal or command prompt, navigate to the `azure-openai\01-HikeBenefitsSummary` directory.

:::zone-end

2. It's now time to try the console application. Type in the following to run the app:

    ```dotnetcli
    dotnet run
    ```

    :::zone target="docs" pivot="azure-openai"
    If you get an error message the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.
    :::zone-end

## Understanding the code

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
<!-- markdownlint-enable MD044 -->

The app uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

The entire application is contained within the **Program.cs** file. The first several lines of code set configuration values and gets the OpenAI Key that was previously set using the `dotnet user-secrets` command.

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = "gpt-3.5-turbo";
string key = config["OpenAIKey"];
```

The `Kernel` class facilitates the requests and responses with the help of `AddOpenAIChatCompletion` service.

```csharp
// Create a Kernel containing the OpenAI Chat Completion Service
Kernel kernel = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(model, key)
    .Build();
```

:::zone-end

:::zone target="docs" pivot="azure-openai"
The application uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the Azure OpenAI service.

The entire application is contained within the **Program.cs** file. The first several lines of code loads up secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
// == Retrieve the local secrets saved during the Azure deployment ==========
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];
string key = config["AZURE_OPENAI_KEY"];
```

The `Kernel` class facilitates the requests and responses with the help of `AddAzureOpenAIChatCompletion` service.

```csharp
// Create a Kernel containing the Azure OpenAI Chat Completion Service
Kernel kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(deployment, endpoint, key)
    .Build();
```

:::zone-end

Once the `Kernel` is created, read the contents of the file `benefits.md` and create a `prompt` to ask the the model to summarize that text.

```csharp
// Create and print out the prompt
string prompt = $"""
    Please summarize the the following text in 20 words or less:
    {File.ReadAllText("benefits.md")}
    """;
Console.WriteLine($"user >>> {prompt}");
```

To have the model generate a response based off `prompt`, use the `InvokePromptAsync` function.

```csharp
// Submit the prompt and print out the response
string response = await kernel.InvokePromptAsync<string>(prompt, new(new OpenAIPromptExecutionSettings() { MaxTokens = 400 }));
Console.WriteLine($"assistant >>> {response}");
```

Customize the text content of the file or the length of the summary to see the differences in the responses.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

:::zone-end

## Next steps

- [Quickstart - Build an AI chat app with .NET](get-started-openai.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
