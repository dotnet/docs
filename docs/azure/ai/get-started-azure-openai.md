---
title: Quickstart - Build an Azure AI chat app with .NET
description: Create a simple chat app using the .NET Azure OpenAI SDK.
ms.date: 02/28/2024
ms.topic: get-started
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want deploy and use sample code to interact to learn from the sample code.
---

Get started with the .NET Azure OpenAI SDK by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `gpt-35-turbo` model deployed into an Azure OpenAI account. Follow these steps to provision Azure OpenAI and learn how to use the .NET Azure OpenAI SDK.

## Prerequisites

- .NET 8.0 SDK - [Install the .NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- An Azure subscription - [Create one for free](https://azure.microsoft.com/free/)
- Azure Developer CLI - [Install or update the Azure Developer CLI](/azure/developer/azure-developer-cli/install-azd)
- Access to [Azure OpenAI service](/azure/ai-services/openai/overview#how-do-i-get-access-to-azure-openai).

## Getting Started

Ensure that you follow the prerequisites to have access to Azure OpenAI Service as well as the Azure Developer CLI, and then follow the following guide to set started with the sample application.

1. Clone/ Download the repository: [dotnet/ai-samples](https://github.com/dotnet/ai-samples)
1. From a terminal or command prompt, navigate to the `01-HikerAI` directory.
1. Create the Azure resources using the Azure Developer CLI:

	```bash
	azd up
	```

    This will provision the Azure OpenAI resources. It may take several minutes to create the Azure OpenAI service and deploy the model.
1. It's now time to try the console application. Type in the following to run the app:

	```bash
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
    var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
    string openAIEndpoint = config["AZURE_OPENAI_ENDPOINT"];
    string openAIDeploymentName = config["AZURE_OPENAI_GPT_NAME"];
    string openAiKey = config["AZURE_OPENAI_KEY"];
    
    // == Creating the AIClient ==========
    var endpoint = new Uri(openAIEndpoint);
    var credentials = new AzureKeyCredential(openAiKey);
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

Then we can add a user message to the model by using the `ChatRequestUserMessage` class. 

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

Customize the system prompt and user message to see how the model responds to help you find a hike that you will like.


## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```bash
azd down

## Troubleshooting

On Windows, after running `azd up` you may get the following error message:
> *postprovision.ps1 is not digitally signed. The script will not execute on the system* 

The script **postprovision.ps1** is executed to set the .NET user secrets used in the application. To avoid this error, run the following Powershell command:

    ```powershell
    Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
    ```

Then re-run the `azd up` command.

## Next steps

- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)

