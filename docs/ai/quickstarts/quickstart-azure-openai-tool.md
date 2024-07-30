---
title: Quickstart - Extend OpenAI using Tools and execute a local Function with .NET 
description: Create a simple chat app using OpenAI and extend the model to execute a local function.
ms.date: 07/14/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code how to extend the model using Tools.
---

# Extend OpenAI using Tools and execute a local Function with .NET

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
<!-- markdownlint-enable MD044 -->

Get started with AI by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-3.5-turbo` model, using Tools to extend the model's capabilities by calling a local .NET method. Follow these steps to get access to OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-openai.md)]

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->

Get started with AI by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-35-turbo` model deployed into an Azure OpenAI account. It uses Tools to extend the model's capabilities by calling a local .NET method. Follow these steps to provision Azure OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-azure-openai.md)]

:::zone-end

## Get the sample project

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [deploy-azd](includes/deploy-azd.md)]

:::zone-end

## Try the the hiker pro sample

<!-- markdownlint-disable MD029 MD044 -->
:::zone target="docs" pivot="openai"

1. From a terminal or command prompt, navigate to the `azure-openai\04-HikerAIPro` directory.

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

1. From a terminal or command prompt, navigate to the `azure-openai\04-HikerAIPro` directory.

2. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    > [!TIP]
    > If you get an error message, the Azure OpenAI resources might not have finished deploying. Wait a couple of minutes and try again.

:::zone-end
<!-- markdownlint-enable MD029 MD044  -->

## Understand the code

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"

The application uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

The entire application is contained within the **Program.cs** file. The first several lines of code set configuration values and get the OpenAI Key that was previously set using the `dotnet user-secrets` command.

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = "gpt-3.5-turbo";
string key = config["OpenAIKey"];
```

The `Kernel` class facilitates the requests and responses with the help of `AddOpenAIChatCompletion` service.

```csharp
// Create a Kernel containing the OpenAI Chat Completion Service
IKernelBuilder b = Kernel.CreateBuilder();

Kernel kernel = b
    .AddOpenAIChatCompletion(model, key)
    .Build();
```

:::zone-end

:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->

The application uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

The entire application is contained within the **Program.cs** file. The first several lines of code loads up secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];
string key = config["AZURE_OPENAI_KEY"];
```

The `Kernel` class facilitates the requests and responses with the help of `AzureOpenAIChatCompletion` service.

```csharp
// Create a Kernel containing the Azure OpenAI Chat Completion Service
IKernelBuilder b = Kernel.CreateBuilder();

Kernel kernel = b
    .AddAzureOpenAIChatCompletion(deployment, endpoint, key)
    .Build();
```

:::zone-end

The functions `ImportPluginFromFunctions` and `CreateFromMethod` define the local function that will be called by the model.

```csharp
// Add a new plugin with a local .NET function that should be available to the AI model
// For convenience and clarity of into the code, this standalone local method handles tool call responses. It will fake a call to a weather API and return the current weather for the specified location.
kernel.ImportPluginFromFunctions("WeatherPlugin",
[
    KernelFunctionFactory.CreateFromMethod(
        ([Description("The city, e.g. Montreal, Sidney")] string location, string unit = null) =>
    {
        // Here you would call a weather API to get the weather for the location
        return "Periods of rain or drizzle, 15 C";
    }, "get_current_weather", "Get the current weather in a given location")
]);
```

Once the `kernel` client is created, the code uses a system prompt to provide context and influence the completion tone and content. Note how the weather is emphasized in the system prompt.

```csharp
ChatHistory chatHistory = new("""
    You are a hiking enthusiast who helps people discover fun hikes in their area.
    You are upbeat and friendly. Good weather is important for a good hike. 
    Only make recommendations if the weather is good or if people insist.
    You introduce yourself when first saying hello. When helping people out,
    you always ask them for this information to inform the hiking recommendation you provide:

    1. Where they are located
    2. What hiking intensity they are looking for

    You will then provide three suggestions for nearby hikes that vary in length
    after you get that information. You will also share an interesting fact about the local
    nature on the hikes when making a recommendation.
    """);
```

The app also adds a user message to the model using the `AddUserMessage` function. The `GetChatMessageContentAsync` function sends the chat history to the model to generate a response based off the system and user prompts.

```csharp
chatHistory.AddUserMessage("""
    Is the weather is good today for a hike?
    If yes, I live in the greater Montreal area and would like an easy hike. 
    I don't mind driving a bit to get there. I don't want the hike to be over 10 miles round trip.
    I'd consider a point-to-point hike.
    I want the hike to be as isolated as possible. I don't want to see many people.
    I would like it to be as bug free as possible.
    """);

Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");

chatHistory.Add(await service.GetChatMessageContentAsync(
    chatHistory, 
    new OpenAIPromptExecutionSettings()
    { 
        MaxTokens = 400 
    }));

Console.WriteLine($"{chatHistory.Last().Role} >>> {chatHistory.Last().Content}");
```

Customize the system prompt and user message to see how the model responds to help you find a hike that you'll like.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

[!INCLUDE [troubleshoot](includes/troubleshoot.md)]

:::zone-end

## Next steps

- [Quickstart - Get insight about your data from a .NET AI chat app](quickstart-ai-chat-with-data.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
