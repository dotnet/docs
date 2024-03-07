---
title: Quickstart - Summarize text using Azure AI chat app with .NET
description: Create a simple chat app using the .NET Azure OpenAI SDK to summarize a text.
ms.date: 03/04/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Summarize text using Azure AI chat app with .NET

Get started with the .NET Azure OpenAI SDK by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-35-turbo` model deployed into an Azure OpenAI account. Follow these steps to provision Azure OpenAI and learn how to use the .NET Azure OpenAI SDK.

[!INCLUDE [download-alert](includes/prerequisites-and-azure-deploy.md)]

## Trying Hiking Benefits Summary sample

1. From a terminal or command prompt, navigate to the `01-HikeBenefitsSummary` directory.
2. It's now time to try the console application. Type in the following to run the app:

    ```dotnetcli
    dotnet run
    ```

    If you get an error message the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.

## Understanding the code

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

Once the `OpenAIClient` client is created, we read the content of the file `benefits.md`. Then using the `ChatRequestUserMessage` class we can add to the model the request to summarize that text.

```csharp
string userRequest = """
Please summarize the the following text in 20 words or less:
""" + markdown;

completionOptions.Messages.Add(new ChatRequestUserMessage(userRequest));
Console.WriteLine($"\n\nUser >>> {userRequest}");
```

To have the model generate a response based off the user request, use the `GetChatCompletionsAsync` function.

```csharp
ChatCompletions response = await openAIClient.GetChatCompletionsAsync(completionOptions);
ChatResponseMessage assistantResponse = response.Choices[0].Message;
Console.WriteLine($"\n\nAssistant >>> {assistantResponse.Content}");
```

Customize the text content of the file or the length of the summary to see the differences in the responses.

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

## Next steps

- [Quickstart - Build an Azure AI chat app with .NET](get-started-azure-openai.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
