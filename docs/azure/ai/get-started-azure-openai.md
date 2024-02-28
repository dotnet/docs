---
title: Quickstart - Build an Azure AI chat app with .NET
description: Get started on how to use the Azure OpenAI with a gpt-35-turbo model, from a simple .NET console application. Get a hiking recommendation from the AI model. It consists of a simple console application, running locally, that will send request to an Azure OpenAI service deployed in your Azure subscription.
ms.date: 02/28/2024
ms.topic: get-started
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want deploy and use sample code to interact to learn from the sample code.
---

This sample demonstrates how to use the Azure OpenAI with a `gpt-35-turbo` model, from a simple .NET 8.0 console application. It consists of a simple console application, running locally, that will send request to an Azure OpenAI service deployed in your Azure subscription. Everything will be deployed automatically using the Azure Developer CLI.

## Requirements

- .NET 8.0 SDK - [Install the .NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- An Azure subscription - [Create one for free](https://azure.microsoft.com/free/)
- Azure Developer CLI - [Install or update the Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)

## Getting Started

Ensure that you follow the prerequisites to have access to Azure OpenAI Service as well as the Azure Developer CLI, and then follow the following guide to set started with the sample application.

1. Clone/ Download the repository: [dotnet/ai-samples](https://github.com/dotnet/ai-samples)
1. From a terminal or command prompt, navigate to the `01-HikerAI` directory.
1. Create the Azure resources using the Azure Developer CLI:
	```bash
	azd up
	```
1. It's now time to try the console application. Depending on your Azure subscription it's possible that a few (~5) minutes more minute are required before the model deployed in Azure OpenAI get available. If you get an error message about this, wait a few minutes and try again.
	```bash
	dotnet run
	```

## How it works

The client library is available through NuGet, as the `Azure.AI.OpenAI` package. Using the client we can send and receive requests to an Azure OpenAI service deployed in Azure.

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

Then we can add a user message to the model, and get the response from the model.

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
completionOptions.Messages.Add(new ChatRequestSystemMessage(assistantResponse.Content)); 
```

Try it out customize the prompt and message and see how the AI model can help you find a hike that you will like.


## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.
```bash
azd down
```

## Troubleshooting

On Windows, you may get an error message: "*postprovision.ps1 is not digitally signed. The script will not execute on the system*" after the deployment. This is cause by the script "postprovision" being executed locally after the deployment to create .NET secret that will be used in the application. To avoid this error, execute the command `Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass`. And re-run the `azd up` command.

## Next steps

### More sample code

- more example coming up soon...


### Learn Module

- [Generate text and conversations with .NET and Azure OpenAI Completions](https://learn.microsoft.com/training/modules/open-ai-dotnet-text-completions/)
