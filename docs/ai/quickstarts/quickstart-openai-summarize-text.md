---
title: Quickstart - Summarize text using an AI chat app with .NET
description: Create a simple chat app using Microsoft.Extensions.AI and the Semantic Kernel SDK to summarize a text.
ms.date: 07/17/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: dotnet-ai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Summarize text using AI chat app with .NET

:::zone target="docs" pivot="microsoft-extensions-ai"

Get started with AI by creating a simple .NET 8.0 console chat app to summarize text. You'll learn how to use the `Microsoft.Extensions.AI` library to connect to an AI model from a local application. This library provides essential abstractions for integrating AI services into .NET applications and libraries.

## Prerequisites

[!INCLUDE [prerequisites](includes/prerequisites-openai.md)]

## Get the sample project

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

## Try the hiking benefits sample

The sample project includes completed apps you can run to connect to your AI model of choice:

# [OpenAI](#tab/openai)

1. From a terminal or command prompt, navigate to the `openai\01-HikeBenefitsSummary` directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>
    ```

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

# [Azure OpenAI](#tab/azure-openai)

1. From a terminal or command prompt, navigate to the `azure-openai\01-HikeBenefitsSummary` directory.

1. Run the following commands to configure your Azure OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AzureOpenAIKey <your-azure-openai-key>
    ```

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

---

## Explore the code

The app uses the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI) package to send and receive requests to the OpenAI service.

The **Program.cs** file contains all of the app code. The first several lines of code set configuration values and get the OpenAI Key that was previously set using the `dotnet user-secrets` command.

# [OpenAI](#tab/openai)

:::code language="csharp" source="./snippets/prompt-completion/extensions-ai/openai/program.cs" range="5-7":::

# [Azure OpenAI](#tab/azure-openai)

:::code language="csharp" source="./snippets/prompt-completion/extensions-azure-openai/openai/program.cs" range="6-8":::

---

The following code obtains an `IChatClient` service configured to connect to the AI Model. The `OpenAI` and `Azure.AI.OpenAI` libraries implement types defined in the `Microsoft.Extensions.AI` library, which enables you to code using the `IChatClient` interface abstraction. This abstraction allows you to change the underlying AI provider to other services by updating only a few lines of code, such as Ollama or Azure Inference models.

# [OpenAI](#tab/openai)

:::code language="csharp" source="./snippets/prompt-completion/extensions-ai/openai/program.cs" range="10-11":::

# [Azure OpenAI](#tab/azure-openai)

:::code language="csharp" source="./snippets/prompt-completion/extensions-azure-openai/openai/program.cs" range="10-12":::

---

The `CompleteAsync` function sends the `prompt` to the model to generate a response.

# [OpenAI](#tab/openai)

:::code language="csharp" source="./snippets/prompt-completion/extensions-ai/openai/program.cs" range="14-22":::

# [Azure OpenAI](#tab/azure-openai)

:::code language="csharp" source="./snippets/prompt-completion/extensions-azure-openai/openai/program.cs" range="15-23":::

Customize the text content of the file or the length of the summary to see the differences in the responses.

:::zone-end

:::zone target="docs" pivot="semantic-kernel"

Get started with AI by creating a simple .NET 8.0 console chat application to summarize text. The application runs locally and uses the OpenAI `gpt-3.5-turbo` model. Follow these steps to get access to OpenAI and learn how to use Semantic Kernel.

## Prerequisites

# [OpenAI](#tab/openai)

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

# [Azure OpenAI](#tab/azure-openai)

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

---

## Get the sample project

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

## Try the hiking benefits sample

# [OpenAI](#tab/openai)

1. From a terminal or command prompt, navigate to the `openai\01-HikeBenefitsSummary` directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>
    ```

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

# [Azure OpenAI](#tab/azure-openai)

1. From a terminal or command prompt, navigate to the `azure-openai\01-HikeBenefitsSummary` directory.

1. Run the `azd up` command to provision the Azure OpenAI resource using the [Azure Developer CLI](/developer/azure-developer-cli/overview). `azd` provisions the Azure OpenAI resources and configures user secrets for you.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AzureOpenAIKey <your-openai-key>
    ```

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

---

## Explore the code

The app uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

The **Program.cs** file contains all of the app code. The first several lines of code set configuration values and get the OpenAI Key that was previously set using the `dotnet user-secrets` command.

# [OpenAI](#tab/openai)

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = "gpt-3.5-turbo";
string key = config["OpenAIKey"];
```

# [Azure OpenAI](#tab/azure-openai)

```csharp
// Retrieve the local secrets saved during the Azure deployment
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];
string key = config["AZURE_OPENAI_KEY"];
```

---

The `Kernel` class facilitates the requests and responses and registers an `OpenAIChatCompletion` service.

```csharp
// Create a Kernel containing the OpenAI Chat Completion Service
Kernel kernel = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(model, key)
    .Build();
```

Once the `Kernel` is created, the app code reads the `benefits.md` file content and uses it to create a `prompt` for model. The prompt instructs the model to summarize the file text content.

```csharp
// Create and print out the prompt
string prompt = $"""
    Please summarize the the following text in 20 words or less:
    {File.ReadAllText("benefits.md")}
    """;
Console.WriteLine($"user >>> {prompt}");
```

The `InvokePromptAsync` function sends the `prompt` to the model to generate a response.

```csharp
// Submit the prompt and print out the response
string response = await kernel.InvokePromptAsync<string>(
    prompt,
    new(new OpenAIPromptExecutionSettings() 
        { 
            MaxTokens = 400 
        })
    );
Console.WriteLine($"assistant >>> {response}");
```

Customize the text content of the file or the length of the summary to see the differences in the responses.

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

:::zone-end

## Next steps

- [Quickstart - Build an AI chat app with .NET](get-started-openai.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
