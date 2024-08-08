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

:::zone target="docs" pivot="openai"

Get started with AI by creating a simple .NET 8.0 console chat application to summarize text. The application runs locally and uses the OpenAI `gpt-3.5-turbo` model. Follow these steps to get access to OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-openai.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

Get started with AI by creating a simple .NET 8.0 console chat application to summarize text. The app runs locally and connects to the OpenAI `gpt-35-turbo` model deployed into Azure OpenAI. Follow these steps to provision the Azure OpenAI service and learn how to use Semantic Kernel.

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

1. From a terminal or command prompt, navigate to the `src\quickstarts\azure-openai\01-HikeBenefitsSummary` directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>

# [Azure Portal](#tab/azure-portal)

1. To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article.

1. From a terminal or command prompt, navigate to the `src\quickstarts\azure-openai\01-HikeBenefitsSummary` directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>

---

:::zone-end

## Try the hiking benefits sample

:::zone target="docs" pivot="openai"

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

:::zone-end

:::zone target="docs" pivot="azure-openai"

1. From a terminal or command prompt, navigate to the `azure-openai\01-HikeBenefitsSummary` directory.

2. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    > [!TIP]
    > If you get an error message, the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.

:::zone-end

## Explore the code

:::zone target="docs" pivot="openai"

The app uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

The **Program.cs** file contains all of the app code. The first several lines of code set configuration values and get the OpenAI Key that was previously set using the `dotnet user-secrets` command.

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = "gpt-3.5-turbo";
string key = config["OpenAIKey"];
```

The `Kernel` class facilitates the requests and responses and registers an `OpenAIChatCompletion` service.

```csharp
// Create a Kernel containing the OpenAI Chat Completion Service
Kernel kernel = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(model, key)
    .Build();
```

:::zone-end

:::zone target="docs" pivot="azure-openai"
The application uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the Azure OpenAI service.

The **Program.cs** file contains all of the app code. The first several lines of code load secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
// Retrieve the local secrets saved during the Azure deployment
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];
string key = config["AZURE_OPENAI_KEY"];
```

The `Kernel` class facilitates the requests and responses and registers an `OpenAIChatCompletion` service.

```csharp
// Create a Kernel containing the Azure OpenAI Chat Completion Service
Kernel kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(deployment, endpoint, key)
    .Build();
```

:::zone-end

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

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

[!INCLUDE [troubleshoot](includes/troubleshoot.md)]

:::zone-end

## Next steps

- [Quickstart - Build an AI chat app with .NET](get-started-openai.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
